using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.Delete
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, Booking>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Booking> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _unitOfWork.BookingRepository.GetBookingByIdAsync(request.Id);
            if (booking == null)
            {
                throw new ObjectNotFoundException($"Booking with ID '{request.Id}' not found.");
            }
            await _unitOfWork.BookingRepository.DeleteBookingAsync(request.Id);
            await _unitOfWork.SaveAsync();
            return booking;
        }
    }
}
