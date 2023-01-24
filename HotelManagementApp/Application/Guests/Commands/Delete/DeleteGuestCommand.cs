using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Commands.Delete
{
    public class DeleteGuestCommand : IRequest<Guest>
    {
        public int Id { get; set; }
    }
}
