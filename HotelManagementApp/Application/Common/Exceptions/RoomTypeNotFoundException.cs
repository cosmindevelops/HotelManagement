namespace Application.Common.Exceptions
{
    public class RoomTypeNotFoundException : Exception
    {
        public RoomTypeNotFoundException()
        : base()
        {
        }

        public RoomTypeNotFoundException(string message)
            : base(message)
        {
        }

        public RoomTypeNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}