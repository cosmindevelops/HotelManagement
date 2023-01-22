using Application.Common.Interfaces;
using Application.DTO;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQueryHandler : IRequestHandler<GetBookingByIdQuery, Booking>
    {
        private readonly IUnitOfWork _context;
        public GetBookingByIdQueryHandler(IUnitOfWork context)
        {
            _context = context;

        }

        public async Task<Booking> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.BookingRepository.GetBookingByIdAsync(request.Id);
        }
    }
}
