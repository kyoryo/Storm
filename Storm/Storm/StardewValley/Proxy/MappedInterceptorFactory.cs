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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System.Reflection;
using Storm.Manipulation;

namespace Storm.StardewValley.Proxy
{
    public class MappedInterceptorFactory<T> : InterceptorFactory<T>
    {
        private Dictionary<string, MethodInfo> callMap = new Dictionary<string, MethodInfo>();

        public IInterceptor CreateInterceptor(T t)
        {
            return new ReflectionInterceptor<T>(t, callMap);
        }

        public void MapCall(string name, MethodInfo mi)
        {
            callMap.Add(name, mi);
        }

        public void Map(Type accessor, Type map, List<Injector> injectors)
        {
            foreach (var method in map.GetMethods())
            {
                var attr = method.GetCustomAttribute<ProxyMap>();
                if (attr != null)
                {
                    callMap.Add(InjectorMetaData.NameOfMethod(accessor, injectors, attr.Name), method);
                }
            }
        }

        private class ReflectionInterceptor<K> : IInterceptor
        {
            private K instance;
            private Dictionary<string, MethodInfo> callMap = new Dictionary<string, MethodInfo>();

            public ReflectionInterceptor(K instance, Dictionary<string, MethodInfo> callMap)
            {
                this.instance = instance;
                this.callMap = callMap;
            }

            public void Intercept(IInvocation invocation)
            {
                if (callMap.ContainsKey(invocation.Method.Name))
                {
                    var method = callMap[invocation.Method.Name];
                    var ret = method.Invoke(instance, new object[] { invocation.Arguments });
                    if (method.ReturnType != typeof(void))
                    {
                        invocation.ReturnValue = ret;
                    }
                    return;
                }
                invocation.Proceed();
            }
        }
    }
}
