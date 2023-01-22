using Application.Common.Interfaces;
using Application.DTO;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Queries.GetAllGuests
{
    public class GetAllGuestsQueryHandler : IRequestHandler<GetAllGuestsQuery, IEnumerable<GuestDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllGuestsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GuestDTO>> Handle(GetAllGuestsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Guest> guests = await _unitOfWork.GuestRepository.GetAllGuestsAsync();
            return guests.Select(g => new GuestDTO
            {
                Id = g.Id,
                FirstName = g.FirstName,
                LastName = g.LastName
            });
        }
    }
}
