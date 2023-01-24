using Domain.Entities;
using Infrastructure.InMemoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.XUnit
{
    public class InMemoryGuestRepositoryTests
    {
        private readonly InMemoryGuestRepository _repository;

        public InMemoryGuestRepositoryTests()
        {
            _repository = new InMemoryGuestRepository();
        }

        [Fact]
        public async Task GetGuestByIdAsync_ReturnsCorrectGuest()
        {
            // Arrange
            var guest = new Guest { Id = 1, FirstName = "John", LastName = "Doe" };
            _repository.AddGuestAsync(guest);

            // Act
            var result = await _repository.GetGuestByIdAsync(1);

            // Assert
            Assert.Equal(guest, result);
        }

        [Fact]
        public async Task GetAllGuestsAsync_ReturnsAllGuests()
        {
            // Arrange
            var guests = new List<Guest>
        {
            new Guest { Id = 1, FirstName = "John", LastName = "Doe" },
            new Guest { Id = 2, FirstName = "Jane", LastName = "Doe" },
            new Guest { Id = 3, FirstName = "Bob", LastName = "Smith" },
        };
            foreach (var guest in guests)
            {
                _repository.AddGuestAsync(guest);
            }

            // Act
            var result = await _repository.GetAllGuestsAsync();

            // Assert
            Assert.Equal(guests, result);
        }

        [Fact]
        public async Task AddGuestAsync_AddsGuestToRepository()
        {
            // Arrange
            var guest = new Guest { Id = 1, FirstName = "John", LastName = "Doe" };

            // Act
            await _repository.AddGuestAsync(guest);
            var result = await _repository.GetGuestByIdAsync(1);

            // Assert
            Assert.Equal(guest, result);
        }

        [Fact]
        public async Task UpdateGuestAsync_UpdatesGuestInRepository()
        {
            // Arrange
            var guest = new Guest { Id = 1, FirstName = "John", LastName = "Doe" };
            _repository.AddGuestAsync(guest);

            // Act
            guest.FirstName = "Jane";
            await _repository.UpdateGuestAsync(guest);
            var result = await _repository.GetGuestByIdAsync(1);

            // Assert
            Assert.Equal(guest, result);
        }

        [Fact]
        public async Task DeleteGuestAsync_DeletesGuestFromRepository()
        {
            // Arrange
            var guest = new Guest { Id = 1, FirstName = "John", LastName = "Doe" };
            _repository.AddGuestAsync(guest);

            // Act
            await _repository.DeleteGuestAsync(1);
            var result = await _repository.GetGuestByIdAsync(1);

            // Assert
            Assert.Null(result);
        }
    }
}
