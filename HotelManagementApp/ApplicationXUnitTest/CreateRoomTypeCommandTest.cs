using Application.RoomTypes.Commands.Create;
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
    public class CreateRoomTypeCommandTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Create_Room_Type_Creates_Room_Type()
        {
            // Arrange
            var createRoomTypeCommand = new CreateRoomTypeCommand
            {
                Title = "Single Room",
                Description = "A room with a single bed",
                Price = 50
            };
            _mockMediator.Setup(x => x.Send(It.IsAny<CreateRoomTypeCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new RoomType
            {
                Id = 1,
                Title = "Single Room",
                Description = "A room with a single bed",
                Price = 50
            }));

            // Act
            var roomType = await _mockMediator.Object.Send(createRoomTypeCommand);

            // Assert
            Assert.NotNull(roomType);
            Assert.Equal(createRoomTypeCommand.Title, roomType.Title);
            Assert.Equal(createRoomTypeCommand.Description, roomType.Description);
            Assert.Equal(createRoomTypeCommand.Price, roomType.Price);
        }
    }
}
