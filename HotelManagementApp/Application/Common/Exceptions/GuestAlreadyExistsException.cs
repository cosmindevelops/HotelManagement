using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class GuestAlreadyExistsException : Exception
    {
        public GuestAlreadyExistsException() : base("Guest already exists.")
        {
        }
        
    }
}
