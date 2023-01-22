using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Queries.GetAllRoomTypes
{
    public class GetAllRoomTypesQueryHandler : IRequestHandler<GetAllRoomTypesQuery, IEnumerable<RoomType>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRoomTypesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RoomType>> Handle(GetAllRoomTypesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.RoomTypeRepository.GetAllRoomTypesAsync();
        }
    }
}
