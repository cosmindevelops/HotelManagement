using Application.Bookings.DTO;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Bookings.Queries.GetAllBookingsQuery
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, IEnumerable<BookingGetDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllBookingsQueryHandler(IUnitOfWork context, IMapper mapper)
        {
            _unitOfWork = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingGetDTO>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllBookingsAsync();
            if (bookings == null)
            {
                throw new BookingNotFoundException();
            }
            return _mapper.Map<IEnumerable<BookingGetDTO>>(bookings);
        }
    }
}