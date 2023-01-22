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

        public Task<Booking> GetBookingByIdAsync(int id)
        {
            return Task.FromResult(_bookings.SingleOrDefault(b => b.Id == id));
        }

        public Task<List<Booking>> GetAllBookingsAsync()
        {
            return Task.FromResult(_bookings);
        }

        public Task AddBookingAsync(Booking booking)
        {
            _bookings.Add(booking);
            return Task.CompletedTask;
        }

        public Task UpdateBookingAsync(Booking booking)
        {
            var index = _bookings.FindIndex(b => b.Id == booking.Id);
            if (index != -1)
            {
                _bookings[index] = booking;
            }
            return Task.CompletedTask;
        }

        public Task DeleteBookingAsync(int id)
        {
            var index = _bookings.FindIndex(b => b.Id == id);
            if (index != -1)
            {
                _bookings.RemoveAt(index);
            }
            return Task.CompletedTask;
        }
    }
}