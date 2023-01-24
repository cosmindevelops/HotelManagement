using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Queries.GetRoomTypeById
{
    public class GetRoomTypeByIdQuery : IRequest<RoomType>
    {
        public int Id { get; set; }
    }
}
