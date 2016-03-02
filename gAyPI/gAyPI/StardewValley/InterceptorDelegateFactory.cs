using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley
{
    public interface InterceptorDelegateFactory<T>
    {
        IInterceptor CreateInterceptor(T t);
    }
}
