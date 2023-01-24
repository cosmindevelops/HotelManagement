using Application.Rooms.Commands.Delete;
using Application.Rooms.Commands.Update;
using Application.Rooms.Queries.GetAllRooms;
using Application.Rooms.Queries.GetRoomById;
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

namespace WebApi.MSTest
{
    [TestClass]
    public class RoomControllerTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [TestMethod]
        public async Task Get_All_Rooms_Should_Call_GetAllRoomsQuery()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllRoomsQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new RoomController(_mockMediator.Object);
            await controller.GetAllRooms();

            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllRoomsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Room_By_Id_Should_Call_GetRoomByIdQuery()
        {
            // Arrange
            int roomId = 1;
            _mockMediator
                .Setup(m => m.Send(It.Is<GetRoomByIdQuery>(q => q.Id == roomId), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new RoomController(_mockMediator.Object);
            await controller.GetRoomById(roomId);

            // Assert
            _mockMediator.Verify(x => x.Send(It.Is<GetRoomByIdQuery>(q => q.Id == roomId), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Delete_Room_DeleteRoomCommandIsCalled()
        {
            // Arrange
            int roomId = 1;
            _mockMediator
                .Setup(m => m.Send(It.Is<DeleteRoomCommand>(q => q.Id == roomId), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new RoomController(_mockMediator.Object);
            await controller.DeleteRoom(roomId);

            // Assert
            _mockMediator.Verify(x => x.Send(It.Is<DeleteRoomCommand>(q => q.Id == roomId), It.IsAny<CancellationToken>()), Times.Once());
        }


    }
}
