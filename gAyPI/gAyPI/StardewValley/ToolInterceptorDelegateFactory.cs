using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System.Diagnostics;

namespace gAyPI.StardewValley
{
    public class ToolInterceptorDelegateFactory : InterceptorDelegateFactory<ToolDelegate>
    {
        public delegate string GetNameDelegate();

        private string getNameMethodName;

        private class ToolInterceptor : IInterceptor
        {
            private string getNameMethodName;
            private GetNameDelegate getNameDelegate;

            public ToolInterceptor(string getNameMethodName, GetNameDelegate getNameDelegate)
            {
                this.getNameMethodName = getNameMethodName;
                this.getNameDelegate = getNameDelegate;
            }

            public void Intercept(IInvocation invocation)
            {
                var method = invocation.Method;
                if (method.Name == getNameMethodName)
                {
                    invocation.ReturnValue = getNameDelegate();
                    return;
                }

                invocation.Proceed();
            }
        }

        public ToolInterceptorDelegateFactory(string getNameMethodName)
        {
            this.getNameMethodName = getNameMethodName;
        }

        public IInterceptor CreateInterceptor(ToolDelegate t)
        {
            return new ToolInterceptor(getNameMethodName, t.GetName);
        }
    }
}
