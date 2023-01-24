using Application.RoomTypes.DTO;
using MediatR;

namespace Application.RoomTypes.Commands.Create
{
    public class CreateRoomTypeCommand : IRequest<RoomTypePostDTO>
    {
        public RoomTypePostDTO RoomType { get; set; }

        public CreateRoomTypeCommand(RoomTypePostDTO roomType)
        {
            RoomType = roomType;
        }
    }
}