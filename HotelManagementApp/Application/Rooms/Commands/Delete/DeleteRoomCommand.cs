using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.Delete
{
    public class DeleteRoomCommand : IRequest<Room>
    {
        public int Id { get; set; }
    }
}
