using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.RoomTypes.DTO;
using AutoMapper;
using MediatR;

namespace Application.RoomTypes.Queries.GetAllRoomTypes
{
    public class GetAllRoomTypesQueryHandler : IRequestHandler<GetAllRoomTypesQuery, IEnumerable<RoomTypeGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRoomTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomTypeGetDTO>> Handle(GetAllRoomTypesQuery request, CancellationToken cancellationToken)
        {
            var roomTypes = await _unitOfWork.RoomTypeRepository.GetAllRoomTypesAsync();
            if (roomTypes == null)
            {
                throw new RoomTypeNotFoundException();
            }
            return _mapper.Map<IEnumerable<RoomTypeGetDTO>>(roomTypes);
        }
    }
}