namespace Application.Common.Exceptions
{
    public class GuestNotFoundException : Exception
    {
        public GuestNotFoundException()
        : base()
        {
        }

        public GuestNotFoundException(string message)
            : base(message)
        {
        }

        public GuestNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}