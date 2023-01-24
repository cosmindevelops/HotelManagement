namespace Application.Common.Exceptions
{
    public class RoomTypeNotFoundException : Exception
    {
        public RoomTypeNotFoundException() : base("RoomType not found.")
        {
        }

        public RoomTypeNotFoundException(int id) : base($"RoomType with id {id} not found.")
        {
        }
    }
}