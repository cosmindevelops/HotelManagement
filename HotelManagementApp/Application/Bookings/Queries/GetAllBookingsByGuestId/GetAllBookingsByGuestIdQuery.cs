using Application.Bookings.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetAllBookingsByGuestId
{
    public class GetAllBookingsByGuestIdQuery : IRequest<IEnumerable<BookingOnlyDTO>>
    {
        public int GuestId { get; set; }
    }
}
