using Application.Bookings.Commands.Create;
using Application.Bookings.Commands.Delete;
using Application.Bookings.Commands.Update;
using Application.Bookings.Queries.GetAllBookingsQuery;
using Application.Bookings.Queries.GetBookingById;
using Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _mediator.Send(new GetAllBookingsQuery());
            return Ok(bookings);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _mediator.Send(new GetBookingByIdQuery { Id = id });
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
        {
            var booking = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, new BookingDTO
            {
                Id = booking.Id,
                RoomId = booking.RoomId,
                GuestId = booking.GuestId,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                TotalCost = booking.TotalCost
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingCommand command)
        {
            command.Id = id;
            var booking = await _mediator.Send(command);
            if (booking == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _mediator.Send(new DeleteBookingCommand { Id = id });
            if (booking == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
