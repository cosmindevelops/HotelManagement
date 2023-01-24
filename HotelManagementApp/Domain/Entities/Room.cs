namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }

        // Navigation properties
        public RoomType RoomType { get; set; }
        
        public ICollection<Booking> Bookings { get; set; }
    }
}