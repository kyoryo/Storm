using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI
{
    public sealed class Logging
    {
        private Logging() { }

        public delegate void Logger(string msg);

        public static Logger Log = null;
    }
}
