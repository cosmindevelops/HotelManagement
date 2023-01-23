//using Application.Bookings.Commands.Create;
//using Domain.Entities;
//using MediatR;
//using Moq;

//namespace Application.XUnitTest
//{
//    public class CreateBookingCommandTest
//    {
//        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

//        [Fact]
//        public async Task Create_Booking_Creates_Booking_In_Database()
//        {
//            // Arrange
//            var room = new Room
//            {
//                Id = 1,
//                RoomNumber = 101,
//                RoomTypeId = 1
//            };
//            var guest = new Guest
//            {
//                Id = 1,
//                FirstName = "Mike",
//                LastName = "Anderson"
//            };
//            var expectedBooking = new Booking
//            {
//                Id = 1,
//                RoomId = room.Id,
//                GuestId = guest.Id,
//                StartDate = DateTime.Now,
//                EndDate = DateTime.Now.AddDays(5),
//                CheckedIn = true,
//                TotalCost = 500
//            };
//            _mockMediator.Setup(x => x.Send(It.IsAny<CreateBookingCommand>(), It.IsAny<CancellationToken>()))
//            .Returns(Task.FromResult(expectedBooking));

//            // Act
//            var booking = await _mockMediator.Object.Send(new CreateBookingCommand
//            {
//                RoomId = room,
//                GuestId = guest,
//                StartDate = DateTime.Now,
//                EndDate = DateTime.Now.AddDays(5),
//                CheckedIn = true,
//                TotalCost = 500
//            });

//            // Assert
//            Assert.NotNull(booking);
//            Assert.Equal(expectedBooking.Id, booking.Id);
//            Assert.Equal(expectedBooking.RoomId, booking.RoomId);
//            Assert.Equal(expectedBooking.GuestId, booking.GuestId);
//            Assert.Equal(expectedBooking.StartDate, booking.StartDate);
//            Assert.Equal(expectedBooking.EndDate, booking.EndDate);
//            Assert.Equal(expectedBooking.CheckedIn, booking.CheckedIn);
//            Assert.Equal(expectedBooking.TotalCost, booking.TotalCost);
//        }
//    }
//}