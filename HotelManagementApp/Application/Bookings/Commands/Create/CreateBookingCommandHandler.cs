using Application.Bookings.DTO;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Guests.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Create
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingPostDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingPostDTO> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            // StartDate or EndDate can't be in the past
            if (DateTime.Now > request.StartDate || DateTime.Now > request.EndDate)
            {
                throw new InvalidBookingDateException();
            }
            // StartDate can't be after EndDate
            if (request.StartDate > request.EndDate)
            {
                throw new InvalidBookingPeriodException();
            }
            
            // Get Guest from DB or create a new one
            var guest = await _unitOfWork.GuestRepository.GetGuestByFullName(request.FirstName, request.LastName);
            if (guest == null)
            {
                guest = new Guest
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };
                await _unitOfWork.GuestRepository.AddGuestAsync(guest);
                await _unitOfWork.SaveAsync();
            }         
            //guest = await _unitOfWork.GuestRepository.GetGuestByFullName(request.FirstName, request.LastName);
            //_mapper.Map<GuestAndBookingDTO>(guest);
            
            var guestDto = _mapper.Map<GuestAndBookingDTO>(guest);
            int guestId = guestDto.Id;
            
            // Get room from DB
            var room = await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.RoomId);

            // Calculate the total cost of the booking
            var startDate = request.StartDate;
            var endDate = request.EndDate;
            TimeSpan duration = endDate - startDate;
            var numberOfDays = (int)duration.TotalDays;
            var totalCost = numberOfDays * room.RoomType.Price;

            var booking = new Booking { GuestId = guestId,
                                    TotalCost = totalCost,
                                    CheckedIn = false,
                                    RoomId=request.RoomId,
                                    StartDate = request.StartDate,
                                    EndDate = request.EndDate};

            await _unitOfWork.BookingRepository.AddBookingAsync(booking);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<BookingPostDTO>(booking);
        }
    }
}