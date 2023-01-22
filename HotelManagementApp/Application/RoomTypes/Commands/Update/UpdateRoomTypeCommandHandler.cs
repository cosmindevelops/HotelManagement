using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Commands.Update
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, RoomType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoomTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomType> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            RoomType roomType = await _unitOfWork.RoomTypeRepository.GetRoomTypeByIdAsync(request.Id);
            if (roomType == null)
            {
                throw new RoomTypeNotFoundException($"Room type with id {request.Id} not found.");
            }

            roomType.Title = request.Title;
            roomType.Description = request.Description;
            roomType.Price = request.Price;

            await _unitOfWork.RoomTypeRepository.UpdateRoomTypeAsync(roomType);
            await _unitOfWork.SaveAsync();

            return roomType;
        }
    }
}
