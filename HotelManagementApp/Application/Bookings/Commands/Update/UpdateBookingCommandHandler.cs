using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.Update
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Booking>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Booking> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _unitOfWork.BookingRepository.GetBookingByIdAsync(request.Id);
            if (booking == null)
            {
                throw new ObjectNotFoundException($"Booking with ID '{request.Id}' not found.");
            }
            booking.RoomId = request.RoomId;
            booking.GuestId = request.GuestId;
            booking.StartDate = request.StartDate;
            booking.EndDate = request.EndDate;
            booking.CheckedIn = request.CheckedIn;
            booking.TotalCost = request.TotalCost;
            await _unitOfWork.BookingRepository.UpdateBookingAsync(booking);
            await _unitOfWork.SaveAsync();
            return booking;
        }
    }
}
