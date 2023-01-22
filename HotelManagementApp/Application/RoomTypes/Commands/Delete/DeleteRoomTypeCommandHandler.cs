using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Commands.Delete
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, RoomType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoomTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomType> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            RoomType roomType = await _unitOfWork.RoomTypeRepository.GetRoomTypeByIdAsync(request.Id);
            if (roomType == null)
            {
                throw new RoomTypeNotFoundException($"Room type with id {request.Id} not found.");
            }

            await _unitOfWork.RoomTypeRepository.DeleteRoomTypeAsync(request.Id);
            await _unitOfWork.SaveAsync();

            return roomType;
        }
    }
}
