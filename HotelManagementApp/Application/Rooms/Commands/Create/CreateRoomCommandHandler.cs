using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Rooms.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Rooms.Commands.Create
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomPostDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoomCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomPostDTO> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {   

            if (request.Room.RoomNumber <= 0 || request.Room.RoomTypeId<=0)
            {
                throw new InvalidRoomException();
            }
            
            var room = _mapper.Map<Room>(request.Room);

            await _unitOfWork.RoomRepository.AddRoomAsync(room);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<RoomPostDTO>(room);
        }
    }
}