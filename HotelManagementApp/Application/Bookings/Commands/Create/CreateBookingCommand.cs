using Application.Bookings.DTO;
using Application.Rooms.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Create
{
    public class CreateBookingCommand : IRequest<BookingPostDTO>
    {
        public BookingPostDTO Booking { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CreateBookingCommand(BookingPostDTO booking, string firstName, string lastName)
        {
            Booking = booking;
            FirstName = firstName;
            LastName = lastName;
            Booking.CheckedIn = false;
        }
    }


    
}