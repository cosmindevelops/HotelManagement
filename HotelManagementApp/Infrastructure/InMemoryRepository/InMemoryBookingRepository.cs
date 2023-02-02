using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.InMemoryRepository
{
    public class InMemoryBookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookings;

        public InMemoryBookingRepository()
        {
            _bookings = new List<Booking>();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await Task.FromResult(_bookings.SingleOrDefault(b => b.Id == id));
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await Task.FromResult(_bookings);
        }

        public async Task AddBookingAsync(Booking booking)
        {
            _bookings.Add(booking);
             await Task.CompletedTask;
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            var index = _bookings.FindIndex(b => b.Id == booking.Id);
            if (index != -1)
            {
                _bookings[index] = booking;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteBookingAsync(int id)
        {
            var index = _bookings.FindIndex(b => b.Id == id);
            if (index != -1)
            {
                _bookings.RemoveAt(index);
            }
            await Task.CompletedTask;
        }

        public Task<IEnumerable<Booking>> GetAllBookingsByGuestId(int guestId)
        {
            throw new NotImplementedException();
        }
    }
}