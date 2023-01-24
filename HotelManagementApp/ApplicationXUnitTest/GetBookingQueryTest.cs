using Application.Bookings.Queries.GetAllBookingsQuery;
using Application.Bookings.Queries.GetBookingById;
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
    public class GetBookingQueryTest
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();

        [Fact]
        public async Task Get_All_Bookings_Returns_Expected_Result()
        {
            // Arrange
            var expectedBookings = new List<Booking>
                {
                    new Booking
                    {
                        Id = 1,
                        RoomId = 1,
                        GuestId = 1,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(1),
                        CheckedIn = true,
                        TotalCost = 100.0m
                    },
                    new Booking
                    {
                        Id = 2,
                        RoomId = 2,
                        GuestId = 2,
                        StartDate = DateTime.Now.AddDays(2),
                        EndDate = DateTime.Now.AddDays(3),
                        CheckedIn = false,
                        TotalCost = 150.0m
                    }
                };
            _mockMediator.Setup(x => x.Send(It.IsAny<GetAllBookingsQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedBookings.AsEnumerable()));
            
            // Act
            var bookings = await _mockMediator.Object.Send(new GetAllBookingsQuery());

            // Assert
            Assert.NotNull(bookings);
            Assert.Equal(2, bookings.Count());
            Assert.Equal(expectedBookings[0].Id, bookings.ElementAt(0).Id);
            Assert.Equal(expectedBookings[0].RoomId, bookings.ElementAt(0).RoomId);
            Assert.Equal(expectedBookings[0].GuestId, bookings.ElementAt(0).GuestId);
            Assert.Equal(expectedBookings[0].StartDate, bookings.ElementAt(0).StartDate);
            Assert.Equal(expectedBookings[0].EndDate, bookings.ElementAt(0).EndDate);
            Assert.Equal(expectedBookings[0].CheckedIn, bookings.ElementAt(0).CheckedIn);
            Assert.Equal(expectedBookings[0].TotalCost, bookings.ElementAt(0).TotalCost);
            Assert.Equal(expectedBookings[1].Id, bookings.ElementAt(1).Id);
            Assert.Equal(expectedBookings[1].RoomId, bookings.ElementAt(1).RoomId);
            Assert.Equal(expectedBookings[1].GuestId, bookings.ElementAt(1).GuestId);
            Assert.Equal(expectedBookings[1].StartDate, bookings.ElementAt(1).StartDate);
            Assert.Equal(expectedBookings[1].EndDate, bookings.ElementAt(1).EndDate);
            Assert.Equal(expectedBookings[1].CheckedIn, bookings.ElementAt(1).CheckedIn);
            Assert.Equal(expectedBookings[1].TotalCost, bookings.ElementAt(1).TotalCost);
        }
        
        [Fact]
        public async Task Get_Booking_By_Id_Returns_Expected_Result()
        {
            // Arrange
            int bookingId = 1;
            var expectedBooking = new Booking
            {
                Id = bookingId,
                RoomId = 1,
                GuestId = 1,
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 1, 3),
                CheckedIn = false,
                TotalCost = 150
            };
            _mockMediator.Setup(x => x.Send(It.Is<GetBookingByIdQuery>(q => q.Id == bookingId), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(expectedBooking));

            // Act
            var booking = await _mockMediator.Object.Send(new GetBookingByIdQuery { Id = bookingId });

            // Assert
            Assert.NotNull(booking);
            Assert.Equal(expectedBooking.Id, booking.Id);
            Assert.Equal(expectedBooking.RoomId, booking.RoomId);
            Assert.Equal(expectedBooking.GuestId, booking.GuestId);
            Assert.Equal(expectedBooking.StartDate, booking.StartDate);
            Assert.Equal(expectedBooking.EndDate, booking.EndDate);
            Assert.Equal(expectedBooking.CheckedIn, booking.CheckedIn);
            Assert.Equal(expectedBooking.TotalCost, booking.TotalCost);
        }
    }
}
