using Application.Guests.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
