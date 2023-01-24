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

namespace Application.Guests.Queries.GetAllBookingGuest
{
    public class GetAllBookingGuestQueryHandler : IRequestHandler<GetAllBookingGuestQuery, GuestAndBookingDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllBookingGuestQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GuestAndBookingDTO> Handle(GetAllBookingGuestQuery request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.GuestRepository.GetGuestByFullName(request.FirstName, request.LastName);

            if (guest == null)
            {
                throw new GuestNotFoundException();
            }
            return _mapper.Map<GuestAndBookingDTO>(guest);
        }
    }

}
