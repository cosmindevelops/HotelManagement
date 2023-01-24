using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Guests.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Guests.Commands.Create
{
    public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, GuestPostDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGuestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GuestPostDTO> Handle(CreateGuestCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Guest.FirstName) || string.IsNullOrEmpty(request.Guest.LastName))
            {
                throw new InvalidGuestException();
            }
            var guest = _mapper.Map<Guest>(request.Guest);

            // Check if guest already exists in the database
            var existingGuest = await _unitOfWork.GuestRepository.GetGuestByFullName(guest.FirstName, guest.LastName);
            if (existingGuest != null)
            {
                throw new GuestAlreadyExistsException();
            }

            await _unitOfWork.GuestRepository.AddGuestAsync(guest);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<GuestPostDTO>(guest);
        }
    }
}