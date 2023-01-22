using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public string Name { get; set; }
        public object Key { get; set; }

        public ObjectNotFoundException(string name, object key)
            : base($"Entity '{name}' ({key}) was not found.")
        {
            Name = name;
            Key = key;
        }
        
        public ObjectNotFoundException()
        : base()
        {
        }

        public ObjectNotFoundException(string message)
            : base(message)
        {
        }

        public ObjectNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
