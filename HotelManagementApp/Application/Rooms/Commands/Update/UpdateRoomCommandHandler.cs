using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Rooms.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Rooms.Commands.Update
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, RoomPutDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomPutDTO> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.Id);
            if (room == null)
            {
                throw new ObjectNotFoundException(nameof(RoomType), request.Id);
            }

            _mapper.Map(request, room);
            await _unitOfWork.RoomRepository.UpdateRoomAsync(room);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<RoomPutDTO>(room);
        }
    }
}