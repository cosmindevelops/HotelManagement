using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.RoomTypes.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.RoomTypes.Commands.Create
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, RoomTypePostDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoomTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomTypePostDTO> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.RoomType.Title) || string.IsNullOrEmpty(request.RoomType.Description) || request.RoomType.Price <= 0)
            {
                throw new InvalidRoomTypeException();
            }
            var roomType = _mapper.Map<RoomType>(request.RoomType);
            
            await _unitOfWork.RoomTypeRepository.AddRoomTypeAsync(roomType);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<RoomTypePostDTO>(roomType);
        }
    }
}