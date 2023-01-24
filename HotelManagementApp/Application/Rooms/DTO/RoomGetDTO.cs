using Application.RoomTypes.DTO;

namespace Application.Rooms.DTO
{
    public class RoomGetDTO
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomTypeGetDTO RoomType { get; set; }
    }
}