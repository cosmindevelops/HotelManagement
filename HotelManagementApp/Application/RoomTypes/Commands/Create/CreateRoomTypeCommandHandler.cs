using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RoomTypes.Commands.Create
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommand, RoomType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RoomType> Handle(CreateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            RoomType roomType = new RoomType
            {
                Title = request.Title,
                Description = request.Description,
                Price = request.Price
            };

            await _unitOfWork.RoomTypeRepository.AddRoomTypeAsync(roomType);
            await _unitOfWork.SaveAsync();

            return roomType;
        }
    }
}
