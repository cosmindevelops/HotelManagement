using Application.Guests.DTO;
using MediatR;

namespace Application.Guests.Queries.GetAllGuests
{
    public class GetAllGuestsQuery : IRequest<IEnumerable<GuestGetDTO>>
    {
    }
}