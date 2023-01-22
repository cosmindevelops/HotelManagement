using Application.Common.Exceptions;
using Application.DTO;
using Application.Rooms.Commands.Create;
using Application.Rooms.Commands.Delete;
using Application.Rooms.Commands.Update;
using Application.Rooms.Queries.GetAllRooms;
using Application.Rooms.Queries.GetRoomById;
using Application.RoomTypes.Queries.GetRoomTypeById;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IMapper _mapper;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
           // _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _mediator.Send(new GetAllRoomsQuery());
            return Ok(rooms);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _mediator.Send(new GetRoomByIdQuery { Id = id });

            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);

        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            var room = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, new RoomDTO
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                RoomTypeId = room.RoomTypeId,
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] UpdateRoomCommand command)
        {
            command.Id = id;
            var room = await _mediator.Send(command);
            if (room == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _mediator.Send(new DeleteRoomCommand
            {
                Id = id
            });
            if (room == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
