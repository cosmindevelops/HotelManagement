using Application.Guests.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
