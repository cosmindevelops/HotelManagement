using Application.Rooms.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Rooms.Queries.GetAllRooms
{
    public class GetAllRoomsQuery : IRequest<IEnumerable<RoomGetDTO>>
    {
    }
}