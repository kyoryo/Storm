using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Proxy
{
    public class CraftingRecipeInterceptFactory : InterceptorDelegateFactory<CraftingRecipeDelegate>
    {
        public IInterceptor CreateInterceptor(CraftingRecipeDelegate t)
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
