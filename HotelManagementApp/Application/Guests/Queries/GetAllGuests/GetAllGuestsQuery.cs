using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Queries.GetAllGuests
{
    public class GetAllGuestsQuery : IRequest<IEnumerable<GuestDTO>>
    {
    }
}
