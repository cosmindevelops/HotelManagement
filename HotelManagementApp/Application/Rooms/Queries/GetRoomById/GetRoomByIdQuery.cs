using Application.Rooms.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Rooms.Queries.GetRoomById
{
    public class GetRoomByIdQuery : IRequest<RoomGetDTO>
    {
        public int Id { get; set; }

        public GetRoomByIdQuery(int id)
        {
            Id = id;
        }
    }
}