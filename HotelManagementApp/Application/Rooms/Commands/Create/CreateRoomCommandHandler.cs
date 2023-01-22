using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rooms.Commands.Create
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Room>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var roomType = await _unitOfWork.RoomTypeRepository.GetRoomTypeByIdAsync(request.RoomTypeId);

            Room room = new Room
            {
                RoomNumber = request.RoomNumber,
                RoomType = roomType
            };

            await _unitOfWork.RoomRepository.AddRoomAsync(room);
            await _unitOfWork.SaveAsync();

            return room;
        }
    }
}
