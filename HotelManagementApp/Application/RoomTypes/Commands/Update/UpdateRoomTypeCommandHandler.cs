using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.RoomTypes.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.RoomTypes.Commands.Update
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, RoomTypePutDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoomTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomTypePutDTO> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = await _unitOfWork.RoomTypeRepository.GetRoomTypeByIdAsync(request.Id);

            if (roomType == null)
            {
                throw new ObjectNotFoundException(nameof(RoomType), request.Id);
            }

            _mapper.Map(request, roomType);
            await _unitOfWork.RoomTypeRepository.UpdateRoomTypeAsync(roomType);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<RoomTypePutDTO>(roomType);
        }
    }
}