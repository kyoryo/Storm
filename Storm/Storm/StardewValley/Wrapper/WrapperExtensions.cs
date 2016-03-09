using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public static class WrapperExtensions
    {
        public static T Cast<T>(this Wrapper @this)
        {
            return (T)@this.Expose();
        }
    }
}
