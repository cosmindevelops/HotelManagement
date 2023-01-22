using Application.Guests.Commands.Update;
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
    public class UpdateGuestCommandTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Update_Guest_Returns_Successful()
        {
            // Arrange
            int guestId = 1;
            Guest expectedGuest = new Guest
            {
                Id = guestId,
                FirstName = "Mike",
                LastName = "Anderson"
            };
            _mockMediator.Setup(x => x.Send(It.Is<UpdateGuestCommand>(c => c.Id == guestId), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(expectedGuest));

            
            // Act
            var guest = await _mockMediator.Object.Send(new UpdateGuestCommand { Id = guestId });

            // Assert
            Assert.NotNull(guest);
            Assert.Equal(expectedGuest.Id, guest.Id);
            Assert.Equal(expectedGuest.FirstName, guest.FirstName);
            Assert.Equal(expectedGuest.LastName, guest.LastName);
        }
    }
}
