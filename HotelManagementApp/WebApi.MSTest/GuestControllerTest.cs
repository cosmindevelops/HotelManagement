using Application.Guests.Commands.Delete;
using Application.Guests.Commands.Update;
using Application.Guests.DTO;
using Application.Guests.Queries.GetAllGuests;
using Application.Guests.Queries.GetGuestById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebAPI.MSTest
{
    [TestClass]
    public class GuestControllerTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [TestMethod]
        public async Task Get_All_Guests_GetAllGuestsQueryIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllGuestsQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new GuestController(_mockMediator.Object);
            await controller.GetAllGuests();

            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllGuestsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Guest_By_Id_GetGuestQueryIsCalled()
        {
            // Arrange
            int guestId = 1;
            _mockMediator
                .Setup(m => m.Send(It.Is<GetGuestByIdQuery>(q => q.Id == guestId), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new GuestController(_mockMediator.Object);
            await controller.GetGuestById(guestId);

            // Assert
            _mockMediator.Verify(x => x.Send(It.Is<GetGuestByIdQuery>(q => q.Id == guestId), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Guest_ById_Returns_Expected_Result()
        {
            // Arrange
            int guestId = 1;
            var expectedGuest = new GuestGetDTO
            {
                Id = guestId,
                FirstName = "Mike",
                LastName = "Anderson"
            };
            _mockMediator.Setup(x => x.Send(It.Is<GetGuestByIdQuery>(q => q.Id == guestId), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedGuest));

            // Act
            var controller = new GuestController(_mockMediator.Object);
            var result = await controller.GetGuestById(guestId);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(expectedGuest, okResult.Value);
        }

        [TestMethod]
        public async Task Get_Guest_By_Id_ShouldReturnOkStatusCode()
        {
            // Arrange
            int guestId = 1;
            var expectedGuest = new GuestGetDTO
            {
                Id = guestId,
                FirstName = "Mike",
                LastName = "Anderson"
            };
            _mockMediator.Setup(x => x.Send(It.Is<GetGuestByIdQuery>(q => q.Id == guestId), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedGuest));

            // Act
            var controller = new GuestController(_mockMediator.Object);
            var result = await controller.GetGuestById(guestId);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [TestMethod]
        public async Task Delete_Guest_DeleteGuestCommandIsCalled()
        {
            // Arrange
            int guestId = 1;
            _mockMediator
                .Setup(m => m.Send(It.Is<DeleteGuestCommand>(q => q.Id == guestId), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new GuestController(_mockMediator.Object);
            await controller.DeleteGuest(guestId);

            // Assert
            _mockMediator.Verify(x => x.Send(It.Is<DeleteGuestCommand>(q => q.Id == guestId), It.IsAny<CancellationToken>()), Times.Once());
        }
        

    }
}
