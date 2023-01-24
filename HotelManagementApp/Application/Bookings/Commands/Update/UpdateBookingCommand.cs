using Application.Bookings.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Update
{
    public class UpdateBookingCommand : IRequest<BookingPutDTO>
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CheckedIn { get; set; }
        public decimal TotalCost { get; set; }
    }
}