using Domain.Entities;
using Infrastructure.InMemoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.XUnit
{
    public class InMemoryBookingRepositoryTests
    {
        private readonly InMemoryBookingRepository _repository;

        public InMemoryBookingRepositoryTests()
        {
            _repository = new InMemoryBookingRepository();
        }

        [Fact]
        public async Task GetBookingByIdAsync_ReturnsCorrectBooking()
        {
            // Arrange
            var booking = new Booking { Id = 1, RoomId = 1, GuestId = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 5), CheckedIn = true, TotalCost = 500 };
            _repository.AddBookingAsync(booking);

            // Act
            var result = await _repository.GetBookingByIdAsync(1);

            // Assert
            Assert.Equal(booking, result);
        }

        [Fact]
        public async Task GetAllBookingsAsync_ReturnsAllBookings()
        {
            // Arrange
            var bookings = new List<Booking>
    {
        new Booking { Id = 1, RoomId = 1, GuestId = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 5), CheckedIn = true, TotalCost = 500 },
        new Booking { Id = 2, RoomId = 2, GuestId = 2, StartDate = new DateTime(2022, 1, 6), EndDate = new DateTime(2022, 1, 10), CheckedIn = true, TotalCost = 1000 },
        new Booking { Id = 3, RoomId = 3, GuestId = 3, StartDate = new DateTime(2022, 1, 11), EndDate = new DateTime(2022, 1, 15), CheckedIn = false, TotalCost = 1500 },
    };
            foreach (var booking in bookings)
            {
                _repository.AddBookingAsync(booking);
            }

            // Act
            var result = await _repository.GetAllBookingsAsync();

            // Assert
            Assert.Equal(bookings, result);
        }

        [Fact]
        public async Task UpdateBookingAsync_UpdatesBookingInRepository()
        {
            // Arrange
            var booking = new Booking { Id = 1, RoomId = 1, GuestId = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 5), CheckedIn = true, TotalCost = 500 };
            _repository.AddBookingAsync(booking);

            // Act
            booking.TotalCost = 1000;
            await _repository.UpdateBookingAsync(booking);
            var result = await _repository.GetBookingByIdAsync(1);

            // Assert
            Assert.Equal(booking, result);
        }

        [Fact]
        public async Task DeleteBookingAsync_DeletesBookingFromRepository()
        {
            // Arrange
            var booking = new Booking { Id = 1, RoomId = 1, GuestId = 1, StartDate = new DateTime(2022, 1, 1), EndDate = new DateTime(2022, 1, 5), CheckedIn = true, TotalCost = 500 };
            _repository.AddBookingAsync(booking);

            // Act
            await _repository.DeleteBookingAsync(1);
            var result = await _repository.GetBookingByIdAsync(1);

            // Assert
            Assert.Null(result);
        }
    }
}
