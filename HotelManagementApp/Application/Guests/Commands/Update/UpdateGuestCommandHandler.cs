using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Guests.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Guests.Commands.Update
{
    public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, GuestPutDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGuestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GuestPutDTO> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.GuestRepository.GetGuestByIdAsync(request.Id);
            if (guest == null)
            {
                throw new ObjectNotFoundException(nameof(Guest), request.Id);
            }

            _mapper.Map(request, guest);

            await _unitOfWork.GuestRepository.UpdateGuestAsync(guest);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<GuestPutDTO>(guest);
        }
    }
}