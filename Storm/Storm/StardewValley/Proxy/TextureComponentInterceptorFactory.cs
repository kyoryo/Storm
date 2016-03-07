using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Storm.StardewValley.Proxy
{
    public class TextureComponentInterceptorFactory : InterceptorDelegateFactory<TextureComponentDelegate>
    {
        public IInterceptor CreateInterceptor(TextureComponentDelegate t)
        {
            return new TextureComponentInterceptor();
        }

        private class TextureComponentInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                invocation.Proceed();
            }
        }
    }
}
