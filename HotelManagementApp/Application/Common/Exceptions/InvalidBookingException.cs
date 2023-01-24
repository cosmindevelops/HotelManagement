using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class InvalidBookingException : Exception
    {
        public InvalidBookingException()
        : base("Invalid booking.")
        {
        }
        
        public InvalidBookingException(int id)
            : base($"Booking with id {id} is invalid.")
        {
        }
    }
}
