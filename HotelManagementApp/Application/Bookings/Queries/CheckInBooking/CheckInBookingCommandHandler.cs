using Application.Bookings.DTO;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.CheckInBooking
{
    public class CheckInBookingCommandHandler : IRequestHandler<CheckInBookingCommand, BookingGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CheckInBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookingGetDTO> Handle(CheckInBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _unitOfWork.BookingRepository.GetBookingByIdAsync(request.BookingId);
            if (booking == null)
            {
                throw new BookingNotFoundException();
            }

            if (booking.Guest.LastName != request.GuestLastName)
            {
                throw new InvalidBookingGuestNameException();
            }
            booking.CheckedIn = true;

            await _unitOfWork.BookingRepository.UpdateBookingAsync(booking);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<BookingGetDTO>(booking);
        }
    }


}
