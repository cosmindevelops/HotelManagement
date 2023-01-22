namespace Application.Common.Exceptions
{
    public class GuestNotFoundException : Exception
    {
        public GuestNotFoundException()
        : base("Guest not found.")
        {
        }

        public GuestNotFoundException(int id)
            : base($"Guest with id {id} not found.")
        {
        }

    }
}