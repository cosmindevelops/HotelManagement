using Application.Bookings.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Queries.GetAllBookingsQuery
{
    public class GetAllBookingsQuery : IRequest<IEnumerable<BookingGetDTO>>
    {
    }
}