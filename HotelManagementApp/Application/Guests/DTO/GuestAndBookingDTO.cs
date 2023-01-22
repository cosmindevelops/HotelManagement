using Application.Bookings.DTO;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.DTO
{
    public class GuestAndBookingDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BookingGetDTO>? Bookings { get; set; }
    }
}
