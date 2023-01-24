using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Commands.Create
{
    public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, Guest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGuestCommandHandler(IUnitOfWork unitOfWork/*, IMapper mapper*/)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guest> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            // Guest guest = _mapper.Map<Guest>(request);
            var guest = new Guest
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            
            await _unitOfWork.GuestRepository.AddGuestAsync(guest);
            await _unitOfWork.SaveAsync();
            return guest;
        }
    }

}
