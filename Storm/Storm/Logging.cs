using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm
{
    public sealed class Logging
    {
        private Logging() { }

        public delegate void Logger(string msg);

        public static Logger Log = (s) => { };
        public static Logger DebugLog = (s) => { };
    }
}
