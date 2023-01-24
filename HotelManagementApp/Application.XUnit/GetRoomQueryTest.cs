using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Rooms.DTO;
using Application.Rooms.Queries.GetAllRooms;
using Application.Rooms.Queries.GetRoomById;
using Application.RoomTypes.DTO;
using AutoMapper;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.XUnit
{
    public class GetRoomQueryTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMapper> _mockMapper;

        public GetRoomQueryTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async void Handle_GetAllRoomQuery_Returns_Expected_Result()
        {
            // Arrange
            var roomType = new RoomType { Id = 1, Title = "Single", Description = "Single room", Price = 50 };
            var room = new Room { Id = 1, RoomNumber = 101, RoomType = roomType };
            var expectedResult = new List<RoomGetDTO>
            {
                new RoomGetDTO { Id = 1, RoomNumber = 101, RoomType = new RoomTypeGetDTO { Id = 1, Title = "Single", Description = "Single room", Price = 50 } }
            };

            _mockUnitOfWork.Setup(x => x.RoomRepository.GetAllRoomsAsync()).ReturnsAsync(new List<Room> { room });
            _mockMapper.Setup(x => x.Map<IEnumerable<RoomGetDTO>>(It.IsAny<List<Room>>())).Returns(expectedResult);
            var queryHandler = new GetAllRoomsQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
            var query = new GetAllRoomsQuery();

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async void Handle_GetAllRoomQuery_RoomsNotFound_Throws_RoomNotFoundException()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.RoomRepository.GetAllRoomsAsync()).ReturnsAsync((List<Room>)null);
            var queryHandler = new GetAllRoomsQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
            var query = new GetAllRoomsQuery();

            // Act & Assert
            await Assert.ThrowsAsync<RoomNotFoundException>(() => queryHandler.Handle(query, CancellationToken.None));
        }

        [Fact]
        public async void Handle_GetRoomByIdQuery_Returns_Expected_Result()
        {
            // Arrange
            var roomType = new RoomType { Id = 1, Title = "Single", Description = "Single room", Price = 50 };
            var room = new Room { Id = 1, RoomNumber = 101, RoomType = roomType };
            var expectedResult = new RoomGetDTO { Id = 1, RoomNumber = 101, RoomType = new RoomTypeGetDTO { Id = 1, Title = "Single", Description = "Single room", Price = 50 } };
            
            _mockUnitOfWork.Setup(x => x.RoomRepository.GetRoomByIdAsync(It.IsAny<int>())).ReturnsAsync(room);
            _mockMapper.Setup(x => x.Map<RoomGetDTO>(It.IsAny<Room>())).Returns(expectedResult);
            var queryHandler = new GetRoomByIdQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
            var query = new GetRoomByIdQuery(1);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task Handle_GetRoomByIdQuery_RoomNotFound_Throws_RoomNotFoundException()
        {
            // Arrange
            _mockUnitOfWork.Setup(x => x.RoomRepository.GetRoomByIdAsync(It.IsAny<int>())).ReturnsAsync((Room)null);
            var queryHandler = new GetRoomByIdQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
            var query = new GetRoomByIdQuery(1);

            // Act and Assert
            await Assert.ThrowsAsync<RoomNotFoundException>(() => queryHandler.Handle(query, CancellationToken.None));
        }

    }
}
