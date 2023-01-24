using Application.DTO;
using Application.RoomTypes.Commands.Create;
using Application.RoomTypes.Commands.Delete;
using Application.RoomTypes.Commands.Update;
using Application.RoomTypes.Queries.GetAllRoomTypes;
using Application.RoomTypes.Queries.GetRoomTypeById;
using Domain.Entities;
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

        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var roomTypes = await _mediator.Send(new GetAllRoomTypesQuery());
            return Ok(roomTypes);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            var roomType = await _mediator.Send(new GetRoomTypeByIdQuery
            {
                Id = id
            });
            if (roomType == null)
            {
                return NotFound();
            }
            return Ok(roomType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomType([FromBody] CreateRoomTypeCommand command)
        {
            var roomType = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRoomTypeById), new { id = roomType.Id }, new RoomTypeDTO
            {
                Id = roomType.Id,
                Title = roomType.Title,
                Description = roomType.Description,
                Price = roomType.Price
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRoomType(int id, [FromBody] UpdateRoomTypeCommand command)
        {
            command.Id = id;
            var roomType = await _mediator.Send(command);
            if (roomType == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRoomType(int id)
        {
            var roomType = await _mediator.Send(new DeleteRoomTypeCommand
            {
                Id = id
            });
            if (roomType == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
