using Application.Common.Exceptions;
using Application.RoomTypes.Commands.Create;
using Application.RoomTypes.Commands.Delete;
using Application.RoomTypes.Commands.Update;
using Application.RoomTypes.Queries.GetAllRoomTypes;
using Application.RoomTypes.Queries.GetRoomTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //DONE
        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            try
            {
                var result = await _mediator.Send(new GetAllRoomTypesQuery());
                return Ok(result);
            }
            catch (RoomTypeNotFoundException ex)
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
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetRoomTypeByIdQuery(id));
                return Ok(result);
            }
            catch (RoomTypeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Done
        [HttpPost]
        public async Task<IActionResult> CreateRoomType([FromBody] CreateRoomTypeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (InvalidRoomTypeException ex)
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
        public async Task<IActionResult> UpdateRoomType(int id, [FromBody] UpdateRoomTypeCommand command)
        {
            try
            {
                command.Id = id;
                var roomType = await _mediator.Send(command);
                return Ok(roomType);
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
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            try
            {
                var roomType = await _mediator.Send(new DeleteRoomTypeCommand(id));
                return Ok(roomType);
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