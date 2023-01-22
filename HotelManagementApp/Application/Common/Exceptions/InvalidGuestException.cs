using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class InvalidGuestException : Exception
    {
        public InvalidGuestException() : base("First Name and Last Name are required fields") { }
        public InvalidGuestException(string message) : base(message) { }
        public InvalidGuestException(string message, Exception innerException) : base(message, innerException) { }
    }
}
