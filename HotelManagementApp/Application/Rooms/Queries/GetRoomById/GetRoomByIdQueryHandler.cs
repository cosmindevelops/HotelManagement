using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Rooms.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Rooms.Queries.GetRoomById
{
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRoomByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomGetDTO> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.Id);
            if (room == null)
            {
                throw new RoomNotFoundException(request.Id);
            }
            return _mapper.Map<RoomGetDTO>(room);
        }
    }
}