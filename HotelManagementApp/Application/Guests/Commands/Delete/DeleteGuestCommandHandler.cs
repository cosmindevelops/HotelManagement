using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Guests.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Guests.Commands.Delete
{
    public class DeleteGuestCommandHandler : IRequestHandler<DeleteGuestCommand, GuestGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGuestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GuestGetDTO> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = await _unitOfWork.GuestRepository.GetGuestByIdAsync(request.Id);
            if (guest == null)
            {
                throw new ObjectNotFoundException(nameof(Guest), request.Id);
            }

            await _unitOfWork.GuestRepository.DeleteGuestAsync(guest.Id);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<GuestGetDTO>(guest);
        }
    }
}