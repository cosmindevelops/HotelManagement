using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetBookingById
{
    public class GetBookingByIdQuery : IRequest<Booking>
    {
        public int Id { get; set; } 
    }
}
