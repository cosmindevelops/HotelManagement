using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class InvalidRoomException : Exception
    {
        public InvalidRoomException() : base("Room Number is invalid")
        {
        }
        public InvalidRoomException(string message) : base(message)
        {
        }

        public InvalidRoomException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
