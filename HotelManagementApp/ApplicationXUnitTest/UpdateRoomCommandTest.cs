using Application.Rooms.Commands.Update;
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
    public class UpdateRoomCommandTest
    {

        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Update_Room_Returns_Successful()
        {
            // Arrange
            int roomId = 1;
            Room expectedRoom = new Room
            {
                Id = roomId,
                RoomNumber = 2,
                RoomTypeId = 2
            };
            _mockMediator.Setup(x => x.Send(It.Is<UpdateRoomCommand>(c => c.Id == roomId), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedRoom));

            // Act
            Room room = await _mockMediator.Object.Send(new UpdateRoomCommand { Id = roomId });

            // Assert
            Assert.NotNull(room);
            Assert.Equal(expectedRoom.Id, room.Id);
            Assert.Equal(expectedRoom.RoomNumber, room.RoomNumber);
            Assert.Equal(expectedRoom.RoomTypeId, room.RoomTypeId);
        }

    }
}
