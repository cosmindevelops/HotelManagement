﻿using Application.Bookings.DTO;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Guests.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Commands.Create
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingPostDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingPostDTO> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            // StartDate and EndDate can't be in the past
            if (DateTime.Now > request.Booking.StartDate || DateTime.Now > request.Booking.EndDate)
            {
                throw new InvalidBookingDateException();
            }
            // StartDate can't be after EndDate
            if (request.Booking.StartDate > request.Booking.EndDate)
            {
                throw new InvalidBookingPeriodException();
            }
            
            var guest = await _unitOfWork.GuestRepository.GetGuestByFullName(request.FirstName, request.LastName);
            if (guest == null)
            {
                guest = new Guest
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };
                await _unitOfWork.GuestRepository.AddGuestAsync(guest);
                await _unitOfWork.SaveAsync();
            }
            
            guest = await _unitOfWork.GuestRepository.GetGuestByFullName(request.FirstName, request.LastName);
            _mapper.Map<GuestAndBookingDTO>(guest);

            int guestId = guest.Id;
            request.Booking.GuestId = guestId;
            
            var room = await _unitOfWork.RoomRepository.GetRoomByIdAsync(request.Booking.RoomId);
            var totalPrice = room.RoomType.Price;
            
            request.Booking.TotalCost = totalPrice;
            var booking = _mapper.Map<Booking>(request.Booking);

            await _unitOfWork.BookingRepository.AddBookingAsync(booking);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<BookingPostDTO>(booking);
        }
    }
}