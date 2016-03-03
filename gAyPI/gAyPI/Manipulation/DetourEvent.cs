using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public class DetourEvent
    {
        private object returnValue;

        public object Source { get; set; }
        public bool ReturnEarly { get; set; }
        public object ReturnValue
        {
            get { return returnValue; }
            set
            {
                returnValue = value;
                ReturnEarly = true;
            }
        }
    }
}
