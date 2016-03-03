using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.ExternalEvent
{
    public abstract class AssemblyModLoader : ModLoader
    {
        public abstract List<LoadedMod> Load();

        protected void LoadModsFromAssembly(Assembly assembly, List<LoadedMod> result)
        {
            var mods = assembly.Modules.SelectMany(m => m.GetTypes()).Where(t => t.GetCustomAttribute(typeof(Mod)) != null);
            foreach (var mod in mods)
            {
                var map = new Dictionary<Type, List<MethodInfo>>();

                var handlers = mod.GetMethods().Where(m => m.GetCustomAttribute(typeof(Subscribe)) != null);
                foreach (var handler in handlers)
                {
                    var @params = handler.GetParameters();
                    if (@params.Length != 1)
                    {
                        Debug.WriteLine("Invalid handler on " + mod.FullName + " " + handler.Name + " " + ReflectionUtils.DescriptionOf(handler));
                        continue;
                    }

                    List<MethodInfo> list;
                    if (!map.TryGetValue(@params[0].ParameterType, out list))
                    {
                        list = new List<MethodInfo>();
                        map.Add(@params[0].ParameterType, list);
                    }
                    list.Add(handler);
                }

                result.Add(new LoadedMod
                {
                    instance = mod.GetConstructor(Type.EmptyTypes).Invoke(null),
                    annotation = mod.GetCustomAttribute<Mod>(),
                    callMap = map,
                });
            }
        }
    }
}
