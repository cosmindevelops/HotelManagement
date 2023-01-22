using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.DTO;
using Application.Guests.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Queries.GetAllGuests
{
    public class GetAllGuestsQueryHandler : IRequestHandler<GetAllGuestsQuery, IEnumerable<GuestGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllGuestsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GuestGetDTO>> Handle(GetAllGuestsQuery request, CancellationToken cancellationToken)
        {
            var guests = await _unitOfWork.GuestRepository.GetAllGuestsAsync();
            if(guests == null)
            {
                throw new GuestNotFoundException();
            }
            return _mapper.Map<IEnumerable<GuestGetDTO>>(guests);
        }
    }
}
