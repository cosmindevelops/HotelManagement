using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Commands.Delete
{
    public class DeleteGuestCommandHandler : IRequestHandler<DeleteGuestCommand, Guest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGuestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guest> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.GuestRepository.GetGuestByIdAsync(request.Id);
            if (guest == null)
            {
                throw new ObjectNotFoundException();
            }

            await _unitOfWork.GuestRepository.DeleteGuestAsync(request.Id);
            await _unitOfWork.SaveAsync();
            return guest;
        }
    }
}
