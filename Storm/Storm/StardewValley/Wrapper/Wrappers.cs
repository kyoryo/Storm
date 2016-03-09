using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public static class Wrappers
    {
        public class ObjectWrapper : Wrapper
        {
            public object Object { get; set; }

            public ObjectWrapper(object o)
            {
                this.Object = o;
            }

            public object Expose() => Object;
        }

        public class IntWrapper : Wrapper
        {
            public int Int { get; set; }

            public IntWrapper(int i)
            {
                this.Int = i;
            }

            public object Expose() => Int;
        }

        public static ObjectWrapper Wrap(object o)
        {
            return new ObjectWrapper(o);
        }

        public static IntWrapper Wrap(int i)
        {
            return new IntWrapper(i);
        }
    }
}
