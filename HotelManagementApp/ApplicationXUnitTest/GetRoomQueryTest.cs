using Application.Rooms.Queries.GetAllRooms;
using Application.Rooms.Queries.GetRoomById;
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
    public class GetRoomQueryTest
    {

        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Get_All_Rooms_Returns_Expected_Result()
        {
            // Arrange
            var expectedRooms = new List<Room>
                {
                    new Room
                    {
                        Id = 1,
                        RoomNumber = 101,
                        RoomTypeId = 1
                    },
                    new Room
                    {
                        Id = 2,
                        RoomNumber = 102,
                        RoomTypeId = 2
                    }
                };
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllRoomsQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRooms.AsEnumerable()));

            // Act
            var rooms = await _mockMediator.Object.Send(new GetAllRoomsQuery());

            // Assert
            Assert.NotNull(rooms);
            Assert.Equal(2, rooms.Count());
            Assert.Equal(expectedRooms[0].Id, rooms.ElementAt(0).Id);
            Assert.Equal(expectedRooms[0].RoomNumber, rooms.ElementAt(0).RoomNumber);
            Assert.Equal(expectedRooms[0].RoomTypeId, rooms.ElementAt(0).RoomTypeId);
            Assert.Equal(expectedRooms[1].Id, rooms.ElementAt(1).Id);
            Assert.Equal(expectedRooms[1].RoomNumber, rooms.ElementAt(1).RoomNumber);
            Assert.Equal(expectedRooms[1].RoomTypeId, rooms.ElementAt(1).RoomTypeId);
        }

        [Fact]
        public async Task Get_Room_By_Id_Returns_Expected_Result()
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
