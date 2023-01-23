using Application.Bookings.DTO;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Update
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, BookingPutDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingPutDTO> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _unitOfWork.BookingRepository.GetBookingByIdAsync(request.Id);
            if (booking == null)
            {
                throw new ObjectNotFoundException(nameof(RoomType), request.Id);
            }

            _mapper.Map(request, booking);
            await _unitOfWork.BookingRepository.UpdateBookingAsync(booking);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BookingPutDTO>(booking);
        }
    }
}