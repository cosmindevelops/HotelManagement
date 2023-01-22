using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.Create
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Booking>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Booking> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.RoomId.Id);
            var guest = await _unitOfWork.GuestRepository.GetGuestByIdAsync(request.GuestId.Id);
            
            var booking = new Booking
            {
                Room = room,
                Guest = guest,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CheckedIn = request.CheckedIn,
                TotalCost = request.TotalCost
            };
            await _unitOfWork.BookingRepository.AddBookingAsync(booking);
            await _unitOfWork.SaveAsync();
            return booking;
        }
    }
}
