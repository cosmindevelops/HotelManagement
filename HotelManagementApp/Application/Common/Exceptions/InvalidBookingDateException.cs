using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class InvalidBookingDateException : Exception
    {
        public InvalidBookingDateException() : base("Start date or end date cannot be in the past") { }
        public InvalidBookingDateException(string message) : base(message)
        {
        }
    }

}
