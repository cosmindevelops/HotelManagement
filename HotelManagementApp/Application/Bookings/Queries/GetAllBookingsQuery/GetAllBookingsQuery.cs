using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetAllBookingsQuery
{
    public class GetAllBookingsQuery : IRequest<IEnumerable<Booking>>
    {
    }
}
