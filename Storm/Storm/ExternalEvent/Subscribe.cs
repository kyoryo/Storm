using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.ExternalEvent
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Subscribe : Attribute
    {
    }
}
