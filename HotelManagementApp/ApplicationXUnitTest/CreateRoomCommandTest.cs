using Application.Rooms.Commands.Create;
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
    
    public class CreateRoomCommandTest
    {

        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        [Fact]
        public async Task Create_Room_Creates_Room()
        {
            // Arrange
            var createRoomCommand = new CreateRoomCommand
            {
                RoomNumber = 101,
                RoomTypeId = 1
            };
            _mockMediator.Setup(x => x.Send(It.IsAny<CreateRoomCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new Room
            {
                Id = 1,
                RoomNumber = 101,
                RoomTypeId = 1
            }));


            // Act
            var room = await _mockMediator.Object.Send(createRoomCommand);

            // Assert
            Assert.NotNull(room);
            Assert.Equal(createRoomCommand.RoomNumber, room.RoomNumber);
            Assert.Equal(createRoomCommand.RoomTypeId, room.RoomTypeId);
        }
    }
}
