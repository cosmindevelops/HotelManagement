using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Guests.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Queries.GetGuestById
{
    public class GetGuestByIdQueryHandler : IRequestHandler<GetGuestByIdQuery, GuestGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGuestByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GuestGetDTO> Handle(GetGuestByIdQuery request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.GuestRepository.GetGuestByIdAsync(request.Id);
            if (guest == null)
            {
                throw new GuestNotFoundException(request.Id);
            }
            return _mapper.Map<GuestGetDTO>(guest);
        }
    }
}
