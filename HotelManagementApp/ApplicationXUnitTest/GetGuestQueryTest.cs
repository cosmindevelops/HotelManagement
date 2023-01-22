using Application.DTO;
using Application.Guests.Queries.GetAllGuests;
using Application.Guests.Queries.GetGuestById;
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
    public class GetGuestQueryTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();


        [Fact]
        public async Task Get_All_Guests_Returns_Expected_Results()
        {
            // Arrange
            var expectedGuests = new List<GuestDTO>
                {
                    new GuestDTO
                    {
                        Id = 1,
                        FirstName = "Mike",
                        LastName = "Anderson"
                    },
                    new GuestDTO
                    {
                        Id = 2,
                        FirstName = "John",
                        LastName = "Harry"
                    }
                };
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllGuestsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedGuests);

            // Act
            var guests = await _mockMediator.Object.Send(new GetAllGuestsQuery());

            // Assert
            Assert.NotNull(guests);
            Assert.Equal(expectedGuests.Count, guests.Count());
            for (int i = 0; i < expectedGuests.Count; i++)
            {
                Assert.Equal(expectedGuests[i].Id, guests.ElementAt(i).Id);
                Assert.Equal(expectedGuests[i].FirstName, guests.ElementAt(i).FirstName);
                Assert.Equal(expectedGuests[i].LastName, guests.ElementAt(i).LastName);
            }
        }
        
        [Fact]
        public async Task Get_Guest_By_Id_Returns_Expected_Result()
        {
            // Arrange
            int guestId = 1;
            var expectedGuest = new Guest
            {
                Id = guestId,
                FirstName = "Mike",
                LastName = "Anderson"
            };
            _mockMediator.Setup(x => x.Send(It.Is<GetGuestByIdQuery>(q => q.Id == guestId), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedGuest));
            
            // Act
            var guest = await _mockMediator.Object.Send(new GetGuestByIdQuery { Id = guestId });

            // Assert
            Assert.NotNull(guest);
            Assert.Equal(expectedGuest.Id, guest.Id);
            Assert.Equal(expectedGuest.FirstName, guest.FirstName);
            Assert.Equal(expectedGuest.LastName, guest.LastName);
        }
    }
}
