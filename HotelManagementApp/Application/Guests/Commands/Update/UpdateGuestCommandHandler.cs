using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Commands.Update
{
    public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, Guest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateGuestCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guest> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.GuestRepository.GetGuestByIdAsync(request.Id);
            if (guest == null)
            {
                throw new ObjectNotFoundException();
            }

            guest.FirstName = request.FirstName;
            guest.LastName = request.LastName;
            await _unitOfWork.SaveAsync();
            return guest;
        }
    }
}
