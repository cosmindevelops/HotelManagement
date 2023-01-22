using Application.Rooms.Queries.GetRoomById;
using Application.RoomTypes.Queries.GetAllRoomTypes;
using Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.XUnitTest
{
    public class GetRoomTypeQueryTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Get_All_Room_Types_Returns_Expected_Result()
        {
            // Arrange
            var expectedRoomTypes = new List<RoomType>
                {
                    new RoomType
                    {
                        Id = 1,
                        Title = "Standard Room",
                        Description = "A standard room with a queen bed and a private bathroom.",
                        Price = 99.99m
                    },
                    new RoomType
                    {
                        Id = 2,
                        Title = "Deluxe Room",
                        Description = "A deluxe room with a king bed, a private bathroom, and a balcony.",
                        Price = 149.99m
                    }
                };
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllRoomTypesQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRoomTypes.AsEnumerable()));

            // Act
            var roomTypes = await _mockMediator.Object.Send(new GetAllRoomTypesQuery());

            // Assert
            Assert.NotNull(roomTypes);
            Assert.Equal(expectedRoomTypes.Count, roomTypes.Count());
            Assert.Equal(expectedRoomTypes[0].Id, roomTypes.ElementAt(0).Id);
            Assert.Equal(expectedRoomTypes[0].Title, roomTypes.ElementAt(0).Title);
            Assert.Equal(expectedRoomTypes[0].Description, roomTypes.ElementAt(0).Description);
            Assert.Equal(expectedRoomTypes[0].Price, roomTypes.ElementAt(0).Price);
            Assert.Equal(expectedRoomTypes[1].Id, roomTypes.ElementAt(1).Id);
            Assert.Equal(expectedRoomTypes[1].Title, roomTypes.ElementAt(1).Title);
            Assert.Equal(expectedRoomTypes[1].Description, roomTypes.ElementAt(1).Description);
            Assert.Equal(expectedRoomTypes[1].Price, roomTypes.ElementAt(1).Price);
        }
        
        [Fact]
        public async Task Get_Room_ById_Returns_Expected_Result()
        {
            // Arrange
            int roomId = 1;
            var expectedRoom = new Room
            {
                Id = roomId,
                RoomNumber = 101,
                RoomTypeId = 1
            };
            _mockMediator.Setup(x => x.Send(It.Is<GetRoomByIdQuery>(q => q.Id == roomId), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRoom));

            // Act
            var room = await _mockMediator.Object.Send(new GetRoomByIdQuery { Id = roomId });

            // Assert
            Assert.NotNull(room);
            Assert.Equal(expectedRoom.Id, room.Id);
            Assert.Equal(expectedRoom.RoomNumber, room.RoomNumber);
            Assert.Equal(expectedRoom.RoomTypeId, room.RoomTypeId);
        }
    }
}
