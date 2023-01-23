using Application.Rooms.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Rooms.Commands.Update
{
    public class UpdateRoomCommand : IRequest<RoomPutDTO>
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
    }
}