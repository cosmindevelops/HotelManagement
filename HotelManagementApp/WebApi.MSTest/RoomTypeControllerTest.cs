using Application.RoomTypes.Queries.GetAllRoomTypes;
using Application.RoomTypes.Queries.GetRoomTypeById;
using Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApi.MSTest
{
    [TestClass]
    public class RoomTypeControllerTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [TestMethod]
        public async Task Get_All_RoomTypes_GetAllRoomTypesQueryIsCalled()
        {
            // Arrange
            _mockMediator
            .Setup(m => m.Send(It.IsAny<GetAllRoomTypesQuery>(), It.IsAny<CancellationToken>()))
            .Verifiable();

           
            // Act
            var controller = new RoomTypeController(_mockMediator.Object);
            await controller.GetAllRoomTypes();

            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllRoomTypesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_RoomType_By_Id_GetRoomTypeQueryIsCalled()
        {
            // Arrange
            int roomTypeId = 1;
            _mockMediator
                .Setup(m => m.Send(It.Is<GetRoomTypeByIdQuery>(q => q.Id == roomTypeId), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new RoomTypeController(_mockMediator.Object);
            await controller.GetRoomTypeById(roomTypeId);

            // Assert
            _mockMediator.Verify(x => x.Send(It.Is<GetRoomTypeByIdQuery>(q => q.Id == roomTypeId), It.IsAny<CancellationToken>()), Times.Once());
        }

    }
}
