using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley
{
    public class ToolInterceptor : IInterceptor
    {
        private ToolDelegate @delegate;

        public ToolInterceptor(ToolDelegate @delegate)
        {
            this.@delegate = @delegate;
        }

        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine(invocation.Method.Name);
            var method = invocation.Method;
            switch (method.Name)
            {
                case "get_Name":
                    invocation.ReturnValue = @delegate.GetName();
                    return;
                case "getDescription":
                    invocation.ReturnValue = "mod?";
                    return;
                case "get_UpgradeLavel":
                    invocation.ReturnValue = 1;
                    return;
                case "get_Stack":
                    invocation.ReturnValue = false;
                    return;
            }
            invocation.Proceed();
        }
    }
}
