using Application.Bookings.Commands.Create;
using Application.Bookings.Commands.Delete;
using Application.Bookings.Commands.Update;
using Application.Bookings.Queries.GetAllBookingsQuery;
using Application.Bookings.Queries.GetBookingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Exceptions;
using Application.Bookings.DTO;
using Application.Bookings.Queries.CheckInBooking;

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
        //DONE
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var result = await _mediator.Send(new GetAllBookingsQuery());
                return Ok(result);
            }
            catch (BookingNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //DONE
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetBookingByIdQuery ( id ));
                return Ok(result);
            }
            catch (BookingNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //TODO - to check
        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (InvalidBookingDateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidBookingPeriodException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        //TODO - to check
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingCommand command)
        {
            try
            {
                command.Id = id;
                var booking = await _mediator.Send(command);
                return Ok(booking);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }        
        }
        //DONE
        [HttpPut]
        [Route("{id}/checkin")]
        public async Task<IActionResult> CheckInBooking(int id, [FromBody] CheckInBookingCommand command)
        {
            command.BookingId = id;
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (InvalidBookingException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //DONE
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                var booking = await _mediator.Send(new DeleteBookingCommand(id));
                return Ok(booking);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}