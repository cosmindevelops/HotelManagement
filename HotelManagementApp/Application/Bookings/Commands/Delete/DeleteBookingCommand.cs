using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.Delete
{
    public class DeleteBookingCommand : IRequest<Booking>
    {
        public int Id { get; set; }
    }
}
