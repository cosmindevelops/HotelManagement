using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetAllBookingsQuery
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, IEnumerable<Booking>>
    {
        private readonly IUnitOfWork _context;
        public GetAllBookingsQueryHandler(IUnitOfWork context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _context.BookingRepository.GetAllBookingsAsync();
        }
    }
}
