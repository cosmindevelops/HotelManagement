namespace Application.Common.Exceptions
{
    public class InvalidGuestException : Exception
    {
        public InvalidGuestException() : base("First Name and Last Name are required fields")
        {
        }

        public InvalidGuestException(string message) : base(message)
        {
        }

        public InvalidGuestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}