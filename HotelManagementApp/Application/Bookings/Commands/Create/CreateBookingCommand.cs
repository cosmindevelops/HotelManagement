using Application.Bookings.DTO;
using Application.Rooms.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Create
{
    public class CreateBookingCommand : IRequest<BookingPostDTO>
    {

        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }


    
}