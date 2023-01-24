using Application.Bookings.Commands.Delete;
using Application.Bookings.DTO;
using Application.Bookings.Queries.GetAllBookingsQuery;
using Application.Bookings.Queries.GetBookingById;
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
    public class BookingControllerTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [TestMethod]
        public async Task Get_All_Bookings_GetAllBookingsQueryIsCalled()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllBookingsQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new BookingController(_mockMediator.Object);
            await controller.GetAllBookings();

            // Assert
            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllBookingsQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Booking_By_Id_GetBookingQueryIsCalled()
        {
            // Arrange
            int bookingId = 1;
            _mockMediator
                .Setup(m => m.Send(It.Is<GetBookingByIdQuery>(q => q.Id == bookingId), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new BookingController(_mockMediator.Object);
            await controller.GetBookingById(bookingId);

            // Assert
            _mockMediator.Verify(x => x.Send(It.Is<GetBookingByIdQuery>(q => q.Id == bookingId), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task Get_Booking_By_Id_ShouldReturnOkStatusCode()
        {
            // Arrange
            int bookingId = 1;
            var expectedBooking = new BookingGetDTO
            {
                Id = bookingId,
                GuestId = 1,
                RoomId = 1,
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 1, 3)
            };
            _mockMediator.Setup(x => x.Send(It.Is<GetBookingByIdQuery>(q => q.Id == bookingId), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedBooking));

            // Act
            var controller = new BookingController(_mockMediator.Object);
            var result = await controller.GetBookingById(bookingId);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(expectedBooking, okResult.Value);
        }

        [TestMethod]
        public async Task Delete_Booking_DeleteBookingCommandIsCalled()
        {
            // Arrange
            int bookingId = 1;
            _mockMediator
                .Setup(m => m.Send(It.Is<DeleteBookingCommand>(q => q.Id == bookingId), It.IsAny<CancellationToken>()))
                .Verifiable();

            // Act
            var controller = new BookingController(_mockMediator.Object);
            await controller.DeleteBooking(bookingId);

            // Assert
            _mockMediator.Verify(x => x.Send(It.Is<DeleteBookingCommand>(q => q.Id == bookingId), It.IsAny<CancellationToken>()), Times.Once());
        }


    }
}
