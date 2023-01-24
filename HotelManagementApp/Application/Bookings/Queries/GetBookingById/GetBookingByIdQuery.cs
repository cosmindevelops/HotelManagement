using Application.Bookings.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQuery : IRequest<BookingGetDTO>
    {
        public int Id { get; set; }
        public GetBookingByIdQuery(int id)
        {
            Id = id;
        }
    }
}