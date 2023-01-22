using Application.Guests.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
