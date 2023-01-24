using Application.Rooms.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Rooms.Commands.Delete
{
    public class DeleteRoomCommand : IRequest<RoomGetDTO>
    {
        public int Id { get; set; }
        public DeleteRoomCommand(int id)
        {
            Id = id;
        }
    }
}