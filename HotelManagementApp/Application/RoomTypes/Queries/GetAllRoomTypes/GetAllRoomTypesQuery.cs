using Application.RoomTypes.DTO;
using MediatR;

namespace Application.RoomTypes.Queries.GetAllRoomTypes
{
    public class GetAllRoomTypesQuery : IRequest<IEnumerable<RoomTypeGetDTO>>
    {
    }
}