using Application.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.Create
{
    public class CreateRoomCommand : IRequest<Room>
    {
        public int RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
    }
}
