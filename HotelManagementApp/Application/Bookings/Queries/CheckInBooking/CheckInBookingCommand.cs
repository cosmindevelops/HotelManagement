using Application.Bookings.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.CheckInBooking
{
    public class CheckInBookingCommand : IRequest<BookingGetDTO>
    {
        public int BookingId { get; set; }
        public string GuestLastName { get; set; }
        public CheckInBookingCommand(int bookingId, string guestLastName)
        {
            BookingId = bookingId;
            GuestLastName = guestLastName;
        }
    }
}
