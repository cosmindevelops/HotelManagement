using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.Delete
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Room>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.Id);
            if (room == null)
            {
                throw new RoomNotFoundException($"Room with id {request.Id} not found.");
            }

            await _unitOfWork.RoomRepository.DeleteRoomAsync(request.Id);
            await _unitOfWork.SaveAsync();

            return room;
        }
    }
}
