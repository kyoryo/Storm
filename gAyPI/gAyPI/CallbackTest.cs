using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gAyPI.Accessor;

namespace gAyPI
{
    public sealed class CallbackTest
    {
        private CallbackTest() { }

        public static string ReturnNigger(object o)
        {
            if (o is FarmerAccessor)
            {
                var casted = o as FarmerAccessor;
                return casted.GetTestx() + " Accessor test!";
            }
            return "nigger";
        }
    }
}
