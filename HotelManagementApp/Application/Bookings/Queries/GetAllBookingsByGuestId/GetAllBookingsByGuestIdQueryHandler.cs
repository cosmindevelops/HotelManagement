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

namespace Application.Bookings.Queries.GetAllBookingsByGuestId
{
    public class GetAllBookingsByGuestIdQueryHandler : IRequestHandler<GetAllBookingsByGuestIdQuery, IEnumerable<BookingOnlyDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllBookingsByGuestIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingOnlyDTO>> Handle(GetAllBookingsByGuestIdQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllBookingsByGuestId(request.GuestId);
            if (bookings == null)
            {
                throw new BookingNotFoundException();
            }

            //return _mapper.Map<IEnumerable<BookingOnlyDTO>>(bookings);
            
            var bookingDTOs = new List<BookingOnlyDTO>();
            foreach (var booking in bookings)
            {
                var bookingDTO = new BookingOnlyDTO
                {
                    Id = booking.Id,
                    RoomId = booking.RoomId,
                    GuestId = booking.GuestId,
                    StartDate = booking.StartDate,
                    EndDate = booking.EndDate,
                    CheckedIn = booking.CheckedIn,
                    TotalCost = booking.TotalCost
                };
                bookingDTOs.Add(bookingDTO);
            }

            return bookingDTOs;
        }
    }
}
