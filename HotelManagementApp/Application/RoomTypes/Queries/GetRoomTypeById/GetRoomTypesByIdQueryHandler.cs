using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.RoomTypes.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Queries.GetRoomTypeById
{
    public class GetRoomTypeByIdQueryHandler : IRequestHandler<GetRoomTypeByIdQuery, RoomTypeGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoomTypeByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomTypeGetDTO> Handle(GetRoomTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var roomType = await _unitOfWork.RoomTypeRepository.GetRoomTypeByIdAsync(request.Id);
            if (roomType == null)
            {
                throw new RoomTypeNotFoundException(request.Id);
            }
            return _mapper.Map<RoomTypeGetDTO>(roomType);
        }
    }
}
