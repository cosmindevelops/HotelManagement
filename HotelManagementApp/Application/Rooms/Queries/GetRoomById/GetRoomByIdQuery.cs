using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.GetRoomById
{
    public class GetRoomByIdQuery : IRequest<Room>
    {
        public int Id { get; set; }
    }
}
