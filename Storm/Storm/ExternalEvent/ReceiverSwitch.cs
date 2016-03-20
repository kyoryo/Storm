using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Storm.ExternalEvent
{
    public struct ReceiverSwitch
    {
        public object Instance;
        public MethodInfo Info;
        public int Priority;
        public bool Enabled;
    }
}
