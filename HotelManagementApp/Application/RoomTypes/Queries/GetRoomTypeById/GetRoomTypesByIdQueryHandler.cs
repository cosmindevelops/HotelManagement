using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Queries.GetRoomTypeById
{
    public class GetRoomTypeByIdQueryHandler : IRequestHandler<GetRoomTypeByIdQuery, RoomType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRoomTypeByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomType> Handle(GetRoomTypeByIdQuery request, CancellationToken cancellationToken)
        {
            RoomType roomType = await _unitOfWork.RoomTypeRepository.GetRoomTypeByIdAsync(request.Id);
            if (roomType == null)
            {
                throw new RoomTypeNotFoundException($"Room type with id {request.Id} not found.");
            }

            return roomType;
        }
    }
}
