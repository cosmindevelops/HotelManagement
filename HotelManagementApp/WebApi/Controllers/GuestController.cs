using Application.Common.Exceptions;
using Application.Guests.Commands.Create;
using Application.Guests.Commands.Delete;
using Application.Guests.Commands.Update;
using Application.Guests.DTO;
using Application.Guests.Queries.GetAllGuests;
using Application.Guests.Queries.GetGuestById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GuestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //DONE
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            try
            {
                var query = new GetGuestByIdQuery(id);
                var guest = await _mediator.Send(query);
                return Ok(guest);
            }
            catch (GuestNotFoundException ex)
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
        public async Task<IActionResult> GetAllGuests()
        {
            try
            {
                var query = new GetAllGuestsQuery();
                var guests = await _mediator.Send(query);
                return Ok(guests);
            }
            catch (GuestNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //DONE
        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] GuestPostDTO guestDto)
        {
            try
            {
                var command = new CreateGuestCommand(guestDto);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (InvalidGuestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //DONE
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] UpdateGuestCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _mediator.Send(command);
                return Ok(result);
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
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            try
            {
                var command = new DeleteGuestCommand(id);
                var result = await _mediator.Send(command);
                return Ok(result);
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