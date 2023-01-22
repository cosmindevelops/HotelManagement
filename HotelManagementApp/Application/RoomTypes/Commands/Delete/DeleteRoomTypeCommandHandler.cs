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

namespace Application.RoomTypes.Commands.Delete
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, RoomTypeGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRoomTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomTypeGetDTO> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = await _unitOfWork.RoomTypeRepository.GetRoomTypeByIdAsync(request.Id);

            if (roomType == null) 
            {
                throw new ObjectNotFoundException(nameof(RoomType), request.Id);
            }
                
            await _unitOfWork.RoomTypeRepository.DeleteRoomTypeAsync(roomType.Id);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<RoomTypeGetDTO>(roomType);
        }
    }
}
