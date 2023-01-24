using Application.RoomTypes.DTO;
using MediatR;

namespace Application.RoomTypes.Commands.Update
{
    public class UpdateRoomTypeCommand : IRequest<RoomTypePutDTO>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}