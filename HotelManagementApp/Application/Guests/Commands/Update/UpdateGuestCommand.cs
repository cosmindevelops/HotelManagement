using Application.Guests.DTO;
using MediatR;

namespace Application.Guests.Commands.Update
{
    public class UpdateGuestCommand : IRequest<GuestPutDTO>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UpdateGuestCommand(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}