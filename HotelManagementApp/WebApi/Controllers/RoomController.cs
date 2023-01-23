using Application.Common.Exceptions;
using Application.DTO;
using Application.Rooms.Commands.Create;
using Application.Rooms.Commands.Delete;
using Application.Rooms.Commands.Update;
using Application.Rooms.Queries.GetAllRooms;
using Application.Rooms.Queries.GetRoomById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoomController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        //DONE
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            try
            {
                var result = await _mediator.Send(new GetAllRoomsQuery());
                return Ok(result);
            }
            catch (RoomNotFoundException ex)
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
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetRoomByIdQuery(id));
                return Ok(result);
            }
            catch (RoomNotFoundException ex)
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
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (InvalidRoomException ex)
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
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] UpdateRoomCommand command)
        {
            try
            {
                command.Id = id;
                var updatedRoom = await _mediator.Send(command);
                return Ok(updatedRoom);
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
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteRoomCommand(id));
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