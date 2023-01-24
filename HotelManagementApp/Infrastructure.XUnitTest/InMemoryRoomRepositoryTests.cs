using Domain.Entities;
using Infrastructure.InMemoryRepository;

namespace Infrastructure.XUnitTest
{
    public class InMemoryRoomRepositoryTests
    {
        private readonly InMemoryRoomRepository _repository;

        public InMemoryRoomRepositoryTests()
        {
            _repository = new InMemoryRoomRepository();
        }

        [Fact]
        public async Task GetRoomByIdAsync_ReturnsCorrectRoom()
        {
            // Arrange
            var room = new Room { Id = 1, RoomNumber = 123, RoomTypeId = 1 };
            _repository.AddRoomAsync(room);

            // Act
            var result = await _repository.GetRoomByIdAsync(1);

            // Assert
            Assert.Equal(room, result);
        }

        [Fact]
        public async Task GetAllRoomsAsync_ReturnsAllRooms()
        {
            // Arrange
            var rooms = new List<Room>
        {
            new Room { Id = 1, RoomNumber = 123, RoomTypeId = 1 },
            new Room { Id = 2, RoomNumber = 124, RoomTypeId = 2 },
            new Room { Id = 3, RoomNumber = 125, RoomTypeId = 3 },
        };
            foreach (var room in rooms)
            {
                _repository.AddRoomAsync(room);
            }

            // Act
            var result = await _repository.GetAllRoomsAsync();

            // Assert
            Assert.Equal(rooms, result);
        }

        [Fact]
        public async Task UpdateRoomAsync_UpdatesRoomInRepository()
        {
            // Arrange
            var room = new Room { Id = 1, RoomNumber = 123, RoomTypeId = 1 };
            _repository.AddRoomAsync(room);

            // Act
            room.RoomNumber = 124;
            await _repository.UpdateRoomAsync(room);
            var result = await _repository.GetRoomByIdAsync(1);

            // Assert
            Assert.Equal(room, result);
        }

        [Fact]
        public async Task DeleteRoomAsync_DeletesRoomFromRepository()
        {
            // Arrange
            var room = new Room { Id = 1, RoomNumber = 123, RoomTypeId = 1 };
            _repository.AddRoomAsync(room);

            // Act
            await _repository.DeleteRoomAsync(1);
            var result = await _repository.GetRoomByIdAsync(1);

            // Assert
            Assert.Null(result);
        }
    }
}