using Application.DTO;
using Application.Guests.Commands.Create;
using Application.Guests.Commands.Delete;
using Application.Guests.Commands.Update;
using Application.Guests.Queries;
using Application.Guests.Queries.GetAllGuests;
using Application.Guests.Queries.GetGuestById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GuestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _mediator.Send(new GetGuestByIdQuery { Id = id });
            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _mediator.Send(new GetAllGuestsQuery());
            return Ok(guests);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] CreateGuestCommand command)
        {
            var guest = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetGuestById), new { id = guest.Id }, new GuestDTO
            {
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] UpdateGuestCommand command)
        {
            command.Id = id;
            var guest = await _mediator.Send(command);

            if (guest == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var guest = await _mediator.Send(new DeleteGuestCommand { Id = id });
            //return Ok(guest);
            if (guest == null)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
