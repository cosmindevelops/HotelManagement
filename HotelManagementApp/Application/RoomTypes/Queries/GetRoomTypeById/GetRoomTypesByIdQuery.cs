using Application.RoomTypes.DTO;
using MediatR;

namespace Application.RoomTypes.Queries.GetRoomTypeById
{
    public class GetRoomTypeByIdQuery : IRequest<RoomTypeGetDTO>
    {
        public int Id { get; set; }

        public GetRoomTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}