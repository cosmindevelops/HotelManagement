using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Rooms.DTO;
using Domain.Entities;
using MediatR;
using AutoMapper;

namespace Application.Rooms.Commands.Delete
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, RoomGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomGetDTO> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.Id);
            
            if (room == null)
            {
                throw new ObjectNotFoundException(nameof(RoomType), request.Id);
            }

            await _unitOfWork.RoomRepository.DeleteRoomAsync(request.Id);
            await _unitOfWork.SaveAsync();
            
            return _mapper.Map<RoomGetDTO>(room);
        }
    }
}