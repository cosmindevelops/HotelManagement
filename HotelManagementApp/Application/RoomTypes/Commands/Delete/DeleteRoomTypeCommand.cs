using Application.RoomTypes.DTO;
using MediatR;

namespace Application.RoomTypes.Commands.Delete
{
    public class DeleteRoomTypeCommand : IRequest<RoomTypeGetDTO>
    {
        public int Id { get; set; }

        public DeleteRoomTypeCommand(int id)
        {
            Id = id;
        }
    }
}