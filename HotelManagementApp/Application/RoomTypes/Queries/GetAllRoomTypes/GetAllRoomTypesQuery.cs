using Application.RoomTypes.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Queries.GetAllRoomTypes
{
    public class GetAllRoomTypesQuery : IRequest<IEnumerable<RoomTypeGetDTO>>
    {
    }
}
