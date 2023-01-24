using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using AutoMapper;
using Application.Bookings.DTO;
using Application.Common.Exceptions;

namespace Application.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, BookingGetDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookingByIdQueryHandler(IUnitOfWork context, IMapper mapper)
        {
            _unitOfWork = context;
            _mapper = mapper;
        }

        public async Task<BookingGetDTO> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            var booking = await _unitOfWork.BookingRepository.GetBookingByIdAsync(request.Id);
            if (booking == null)
            {
                throw new BookingNotFoundException(request.Id);
            }
            return _mapper.Map<BookingGetDTO>(booking);
        }
    }
}