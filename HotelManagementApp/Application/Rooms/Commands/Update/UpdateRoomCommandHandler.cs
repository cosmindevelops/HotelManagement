using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.Update
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Room>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRoomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.Id);
            if (room == null)
            {
                throw new RoomNotFoundException($"Room with id {request.Id} not found.");
            }

            room.RoomNumber = request.RoomNumber;
            room.RoomTypeId = request.RoomTypeId;

            await _unitOfWork.RoomRepository.UpdateRoomAsync(room);
            await _unitOfWork.SaveAsync();

            return room;
        }
    }
}
