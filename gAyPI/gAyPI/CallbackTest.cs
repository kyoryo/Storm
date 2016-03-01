using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using gAyPI.Accessor;

namespace gAyPI
{
    public sealed class CallbackTest
    {
        private CallbackTest() { }

        public static ProgramAccessor entry = null;

        public static string ReturnNigger(object o)
        {
            return "nigger";
        }

        public static void OnDraw()
        {
            entry.GetGame();
        }
    }
}
