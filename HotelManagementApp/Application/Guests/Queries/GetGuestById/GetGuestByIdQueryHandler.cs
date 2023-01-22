using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Queries.GetGuestById
{
    public class GetGuestByIdQueryHandler : IRequestHandler<GetGuestByIdQuery, Guest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGuestByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guest> Handle(GetGuestByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.GuestRepository.GetGuestByIdAsync(request.Id);
        }
    }
}
