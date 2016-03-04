using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm
{
    public class TypeCollisionException : Exception
    {
        public TypeCollisionException() : base() { }

        public TypeCollisionException(string message) : base(message) { }

        public TypeCollisionException(string message, Exception innerException) : base(message, innerException) { }
    }
}
