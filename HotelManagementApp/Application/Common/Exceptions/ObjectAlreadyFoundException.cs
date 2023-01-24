using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class ObjectAlreadyFoundException : Exception
    {
        public ObjectAlreadyFoundException()
        {
        }

        public ObjectAlreadyFoundException(string message)
            : base(message)
        {
        }

        public ObjectAlreadyFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
