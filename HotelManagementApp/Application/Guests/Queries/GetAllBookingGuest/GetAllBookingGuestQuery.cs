using Application.Guests.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Queries.GetAllBookingGuest
{
    public class GetAllBookingGuestQuery : IRequest<GuestAndBookingDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GetAllBookingGuestQuery(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
