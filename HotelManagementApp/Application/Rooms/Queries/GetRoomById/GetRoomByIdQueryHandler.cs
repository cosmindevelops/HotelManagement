using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Queries.GetRoomById
{
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, Room>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoomByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.Id);
            
        }
    }
}
