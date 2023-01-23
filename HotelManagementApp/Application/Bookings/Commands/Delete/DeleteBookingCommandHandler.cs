using Application.Bookings.DTO;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Delete
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, BookingGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingGetDTO> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _unitOfWork.BookingRepository.GetBookingByIdAsync(request.Id);
            if (booking == null)
            {
                throw new ObjectNotFoundException(nameof(Booking), request.Id);
            }
                

            await _unitOfWork.BookingRepository.DeleteBookingAsync(booking.Id);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BookingGetDTO>(booking);
        }
    }
}