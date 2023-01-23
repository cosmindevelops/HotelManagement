using Application.Guests.DTO;
using Application.Rooms.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.DTO
{
    public class BookingGetDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CheckedIn { get; set; }
        public decimal TotalCost { get; set; }
        
        public RoomGetDTO Room { get; set; }
        public GuestGetDTO Guest { get; set; }
    }
}
