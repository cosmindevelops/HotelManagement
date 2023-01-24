using Application.Rooms.DTO;
using Application.RoomTypes.DTO;
using MediatR;

namespace Application.Rooms.Commands.Create
{
    public class CreateRoomCommand : IRequest<RoomPostDTO>
    {
        public RoomPostDTO Room { get; set; }
        public CreateRoomCommand(RoomPostDTO room)
        {
            Room = room;
        }
    }
}