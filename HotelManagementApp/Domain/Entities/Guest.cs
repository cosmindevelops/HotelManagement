namespace Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation properties
        public ICollection<Booking> Bookings { get; set; }
    }
}