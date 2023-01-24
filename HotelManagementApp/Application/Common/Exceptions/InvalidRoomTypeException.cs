namespace Application.Common.Exceptions
{
    public class InvalidRoomTypeException : Exception
    {
        public InvalidRoomTypeException() : base("Title, Description and Price are required fields and Price must be greater than 0")
        {
        }

        public InvalidRoomTypeException(string message) : base(message)
        {
        }

        public InvalidRoomTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}