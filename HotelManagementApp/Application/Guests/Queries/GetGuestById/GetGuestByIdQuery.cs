using Application.Guests.DTO;
using MediatR;

namespace Application.Guests.Queries.GetGuestById
{
    public class GetGuestByIdQuery : IRequest<GuestGetDTO>
    {
        public int Id { get; set; }

        public GetGuestByIdQuery(int id)
        {
            Id = id;
        }
    }
}