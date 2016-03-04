/*
    Copyright 2016 Cody R. (Demmonic)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using Castle.DynamicProxy;

namespace Storm.StardewValley
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
