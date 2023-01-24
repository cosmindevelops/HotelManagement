using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class InvalidBookingGuestNameException : Exception
    {
        public InvalidBookingGuestNameException()
        : base("No booking for that Last Name.")
        {
        }

        public InvalidBookingGuestNameException(string name)
            : base($"No booking for Last Name: {name}.")
        {
        }
    }
}
