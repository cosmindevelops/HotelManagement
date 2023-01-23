//using Domain.Entities;
//using Infrastructure.InMemoryRepository;

//namespace Infrastructure.XUnitTest
//{
//    public class InMemoryRoomTypeRepositoryTests
//    {
//        private readonly InMemoryRoomTypeRepository _repository;

//        public InMemoryRoomTypeRepositoryTests()
//        {
//            _repository = new InMemoryRoomTypeRepository();
//        }

//        [Fact]
//        public async Task GetRoomTypeByIdAsync_ReturnsCorrectRoomType()
//        {
//            // Arrange
//            var roomType = new RoomType { Id = 1, Title = "Standard", Description = "Standard room", Price = 100 };
//            _repository.AddRoomTypeAsync(roomType);

//            // Act
//            var result = await _repository.GetRoomTypeByIdAsync(1);

//            // Assert
//            Assert.Equal(roomType, result);
//        }

//        [Fact]
//        public async Task GetAllRoomTypesAsync_ReturnsAllRoomTypes()
//        {
//            // Arrange
//            var roomTypes = new List<RoomType>
//        {
//            new RoomType { Id = 1, Title = "Standard", Description = "Standard room", Price = 100 },
//            new RoomType { Id = 2, Title = "Deluxe", Description = "Deluxe room", Price = 150 },
//            new RoomType { Id = 3, Title = "Suite", Description = "Suite room", Price = 200 },
//        };
//            foreach (var roomType in roomTypes)
//            {
//                _repository.AddRoomTypeAsync(roomType);
//            }

//            // Act
//            var result = await _repository.GetAllRoomTypesAsync();

//            // Assert
//            Assert.Equal(roomTypes, result);
//        }

//        [Fact]
//        public async Task UpdateRoomTypeAsync_UpdatesRoomTypeInRepository()
//        {
//            // Arrange
//            var roomType = new RoomType { Id = 1, Title = "Standard", Description = "Standard room", Price = 100 };
//            _repository.AddRoomTypeAsync(roomType);

//            // Act
//            roomType.Title = "Deluxe";
//            await _repository.UpdateRoomTypeAsync(roomType);
//            var result = await _repository.GetRoomTypeByIdAsync(1);

//            // Assert
//            Assert.Equal(roomType, result);
//        }

//        [Fact]
//        public async Task DeleteRoomTypeAsync_DeletesRoomTypeFromRepository()
//        {
//            // Arrange
//            var roomType = new RoomType { Id = 1, Title = "Standard", Description = "Standard room", Price = 100 };
//            _repository.AddRoomTypeAsync(roomType);

//            // Act
//            await _repository.DeleteRoomTypeAsync(1);
//            var result = await _repository.GetRoomTypeByIdAsync(1);

//            // Assert
//            Assert.Null(result);
//        }
//    }
//}