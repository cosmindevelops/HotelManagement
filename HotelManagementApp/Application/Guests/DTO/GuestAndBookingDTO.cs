using Application.Bookings.DTO;

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