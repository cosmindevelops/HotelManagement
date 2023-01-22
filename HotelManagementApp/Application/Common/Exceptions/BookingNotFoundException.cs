namespace Application.Common.Exceptions
{
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException()
        : base()
        {
        }

        public BookingNotFoundException(string message)
            : base(message)
        {
        }

        public BookingNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}