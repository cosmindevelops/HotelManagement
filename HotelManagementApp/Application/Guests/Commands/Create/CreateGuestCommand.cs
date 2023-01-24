using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Commands.Create
{
    public class CreateGuestCommand : IRequest<Guest>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
