using Application.Common.Interfaces;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context,
            IGuestRepository guestRepository,
            IRoomRepository roomRepository,
            IRoomTypeRepository roomTypeRepository,
            IBookingRepository bookingRepository)
        {
            _context = context;
            GuestRepository = guestRepository;
            RoomRepository = roomRepository;
            RoomTypeRepository = roomTypeRepository;
            BookingRepository = bookingRepository;
        }

        public IGuestRepository GuestRepository { get; private set; }
        public IRoomRepository RoomRepository { get; private set; }
        public IRoomTypeRepository RoomTypeRepository { get; private set; }
        public IBookingRepository BookingRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}