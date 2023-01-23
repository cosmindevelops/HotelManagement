using Application.RoomTypes.Queries.GetAllRoomTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApi.MSTest
{
    [TestClass]
    public class RoomTypeControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly RoomTypeController _controller;

        public RoomTypeControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new RoomTypeController(_mockMediator.Object);
        }

        [TestMethod]
        public async Task GetAllRoomTypes_ReturnsOkResult()
        {
            // Arrange
            //_mockMediator.Setup(x => x.Send(It.IsAny<GetAllRoomTypesQuery>(), It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(new List<RoomTypeDTO>());

            // Act
            var result = await _controller.GetAllRoomTypes();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
