namespace Application.Common.Exceptions
{
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException()
        : base("Booking not found.")
        {
        }

        public BookingNotFoundException(int id)
            : base($"Booking with id {id} not found.")
        {
        }

    }
}