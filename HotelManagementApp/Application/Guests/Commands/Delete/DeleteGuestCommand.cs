using Application.Guests.DTO;
using MediatR;

namespace Application.Guests.Commands.Delete
{
    public class DeleteGuestCommand : IRequest<GuestGetDTO>
    {
        public int Id { get; set; }

        public DeleteGuestCommand(int id)
        {
            Id = id;
        }
    }
}