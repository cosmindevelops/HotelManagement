namespace Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBookingRepository BookingRepository { get; }
        public IGuestRepository GuestRepository { get; }
        public IRoomRepository RoomRepository { get; }
        public IRoomTypeRepository RoomTypeRepository { get; }

        Task SaveAsync();
    }
}