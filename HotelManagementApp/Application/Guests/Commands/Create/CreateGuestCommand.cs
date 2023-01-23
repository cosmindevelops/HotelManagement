using Application.Guests.DTO;
using MediatR;

namespace Application.Guests.Commands.Create
{
    public class CreateGuestCommand : IRequest<GuestPostDTO>
    {
        public GuestPostDTO Guest { get; set; }

        public CreateGuestCommand(GuestPostDTO guest)
        {
            Guest = guest;
        }
    }
}