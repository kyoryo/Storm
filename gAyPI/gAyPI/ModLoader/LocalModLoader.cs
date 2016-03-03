using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using gAyPI.StardewValley;
using System.Diagnostics;

namespace gAyPI.ModLoader
{
    public class LocalModLoader : IModLoader
    { 
        private string path;

        public LocalModLoader(string path = "./")
        {
            this.path = path;
        }

        public List<LoadedMod> Load()
        {
            var dirs = Directory.GetDirectories(path);
            var result = new List<LoadedMod>();
            foreach (var str in dirs)
            {
                LoadMod(result, str);
            }
            return result;
        }

        private void LoadMod(List<LoadedMod> result, string path)
        {
            var files = Directory.GetFiles(path, "*.dll");
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                var mods = assembly.Modules.SelectMany(m => m.GetTypes()).Where(t => t.GetCustomAttribute(typeof(Mod)) != null);
                foreach (var mod in mods)
                {
                    var map = new Dictionary<Type, List<MethodInfo>>();
                    
                    var handlers = mod.GetMethods().Where(m => m.GetCustomAttribute(typeof(StardewValley.Subscribe)) != null);
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
}
