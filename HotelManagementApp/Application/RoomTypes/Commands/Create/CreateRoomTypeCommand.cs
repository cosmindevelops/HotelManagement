using Application.RoomTypes.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Commands.Create
{
    public class CreateRoomTypeCommand : IRequest<RoomTypePostDTO>
    {
        public RoomTypePostDTO RoomType { get; set; }
        public CreateRoomTypeCommand(RoomTypePostDTO roomType)
        {
            RoomType = roomType;
        }
    }

}
