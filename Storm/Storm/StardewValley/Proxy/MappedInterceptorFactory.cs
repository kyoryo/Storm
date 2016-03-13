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
using System.Reflection;
using Castle.DynamicProxy;
using Storm.Manipulation;

namespace Storm.StardewValley.Proxy
{
    public class MappedInterceptorFactory<T> : InterceptorFactory<T>
    {
        private readonly Dictionary<NameDescCombo, MethodInfo> callMap = new Dictionary<NameDescCombo, MethodInfo>();

        public IInterceptor CreateInterceptor(T t)
        {
            return new ReflectionInterceptor<T>(t, callMap);
        }

        public void MapCall(string name, string desc, MethodInfo mi)
        {
            callMap.Add(new NameDescCombo
            {
                name = name,
                desc = desc,
            }, mi);
        }

        public void Map(Type accessor, Type map, List<Injector> injectors)
        {
            var cur = map;
            while (cur != null && cur != typeof(object))
            {
                foreach (var method in cur.GetMethods())
                {
                    var attr = method.GetCustomAttribute<ProxyMap>();
                    if (attr != null)
                    {
                        var desc = InjectorMetaData.FilterTags(injectors, attr.Desc);
                        var name = InjectorMetaData.NameOfMethod(accessor, injectors, attr.Name, desc);
                        if (name == null)
                        {
                            Logging.Logs("[{0}] Failed to find obfuscated name to map", GetType().Name);
                            Logging.Logs("\t{0} {1} {2} {3}", accessor.Name, attr.Name, desc, method.Name);
                            continue;
                        }
                        MapCall(name, desc, method);
                    }
                }
                cur = cur.BaseType;
            }
        }

        private class ReflectionInterceptor<K> : IInterceptor
        {
            private readonly Dictionary<NameDescCombo, MethodInfo> callMap = new Dictionary<NameDescCombo, MethodInfo>();
            private readonly K instance;

            public ReflectionInterceptor(K instance, Dictionary<NameDescCombo, MethodInfo> callMap)
            {
                this.instance = instance;
                this.callMap = callMap;
            }

            private MethodInfo GetMapped(MethodInfo calling)
            {
                var desc = ReflectionUtils.DescriptionOf(calling);
                foreach (var entry in callMap)
                {
                    if (entry.Key.name == calling.Name && entry.Key.desc == desc)
                    {
                        return entry.Value;
                    }
                }
                return null;
            }

            public void Intercept(IInvocation invocation)
            {
                var method = GetMapped(invocation.Method);
                if (method != null)
                {
                    var ret = method.Invoke(instance, new object[] { invocation.Arguments });
                    if (!(ret is OverrideEvent))
                    {
                        throw new InvalidOperationException("What the fuck?");
                    }

                    var casted = (OverrideEvent)ret;
                    if (casted.ReturnEarly)
                    {
                        invocation.ReturnValue = casted.ReturnValue;
                        return;
                    }
                }
                invocation.Proceed();
            }
        }

        private struct NameDescCombo
        {
            public string name;
            public string desc;
        }
    }
}