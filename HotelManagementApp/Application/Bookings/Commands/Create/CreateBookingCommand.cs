using Application.Bookings.DTO;
using Application.Rooms.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Create
{
    public class CreateBookingCommand : IRequest<BookingPostDTO>
    {
        public BookingPostDTO Booking { get; set; }
        public CreateBookingCommand(BookingPostDTO booking)
        {
            Booking = booking;
            Booking.CheckedIn = false;
        }
    }


    
}