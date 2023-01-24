using Application.RoomTypes.Commands.Update;
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
    public class UpdateRoomTypeCommandTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Update_RoomType_Returns_Successful()
        {
            // Arrange
            int roomTypeId = 1;
            RoomType expectedRoomType = new RoomType
            {
                Id = roomTypeId,
                Title = "Standard",
                Description = "Standard Room",
                Price = 100
            };
            _mockMediator.Setup(x => x.Send(It.Is<UpdateRoomTypeCommand>(c => c.Id == roomTypeId), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(expectedRoomType));


            // Act
            RoomType roomType = await _mockMediator.Object.Send(new UpdateRoomTypeCommand { Id = roomTypeId });

            // Assert
            Assert.NotNull(roomType);
            Assert.Equal(expectedRoomType.Id, roomType.Id);
            Assert.Equal(expectedRoomType.Title, roomType.Title);
            Assert.Equal(expectedRoomType.Description, roomType.Description);
            Assert.Equal(expectedRoomType.Price, roomType.Price);
        }
    }
}
