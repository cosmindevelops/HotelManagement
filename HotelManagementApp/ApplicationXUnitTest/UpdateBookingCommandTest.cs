using Application.Bookings.Commands.Update;
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
    public class UpdateBookingCommandTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Update_Booking_Returns_Successful()
        {
            // Arrange
            int bookingId = 1;
            DateTime startDate = new DateTime(2022, 1, 1);
            DateTime endDate = new DateTime(2022, 1, 3);
            Booking expectedBooking = new Booking
            {
                Id = bookingId,
                GuestId = 1,
                RoomId = 1,
                StartDate = startDate,
                EndDate = endDate
            };
            _mockMediator.Setup(x => x.Send(It.Is<UpdateBookingCommand>(c => c.Id == bookingId), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedBooking));

            // Act
            Booking booking = await _mockMediator.Object.Send(new UpdateBookingCommand
            {
                Id = bookingId,
                StartDate = startDate,
                EndDate = endDate
            });

            // Assert
            Assert.NotNull(booking);
            Assert.Equal(expectedBooking.Id, booking.Id);
            Assert.Equal(expectedBooking.GuestId, booking.GuestId);
            Assert.Equal(expectedBooking.RoomId, booking.RoomId);
            Assert.Equal(expectedBooking.StartDate, booking.StartDate);
            Assert.Equal(expectedBooking.EndDate, booking.EndDate);
        }
    }
}
