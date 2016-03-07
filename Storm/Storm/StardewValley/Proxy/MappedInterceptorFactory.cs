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
    public class ReflectionInterceptorDelegateFactory<T> : InterceptorDelegateFactory<T>
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
                    var ret = method.Invoke(instance, invocation.Method.GetParameters());
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
