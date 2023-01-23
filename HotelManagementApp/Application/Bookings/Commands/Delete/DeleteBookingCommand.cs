using Application.Bookings.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Delete
{
    public class DeleteBookingCommand : IRequest<BookingGetDTO>
    {
        public int Id { get; set; }

        public DeleteBookingCommand(int id)
        {
            Id = id;
        }
    }
}