using Application.Guests.Commands.Create;
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
    public  class CreateGuestCommandTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Create_Guest_Creates_Guest()
        {
            // Arrange
            var createGuestCommand = new CreateGuestCommand
            {
                FirstName = "Mike",
                LastName = "Anderson"
            };
            _mockMediator.Setup(x => x.Send(It.IsAny<CreateGuestCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new Guest
            {
                Id = 1,
                FirstName = "Mike",
                LastName = "Anderson"
            }));


            // Act
             var guest = await _mockMediator.Object.Send(createGuestCommand);

            // Assert
            Assert.NotNull(guest);
            Assert.Equal(createGuestCommand.FirstName, guest.FirstName);
            Assert.Equal(createGuestCommand.LastName, guest.LastName);
        }
    }
}
