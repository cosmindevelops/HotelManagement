using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Rooms.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Rooms.Queries.GetAllRooms
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRoomsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomGetDTO>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _unitOfWork.RoomRepository.GetAllRoomsAsync();
            if (rooms == null)
            {
                throw new RoomNotFoundException();
            }
            return _mapper.Map<IEnumerable<RoomGetDTO>>(rooms);
        }
    }
}