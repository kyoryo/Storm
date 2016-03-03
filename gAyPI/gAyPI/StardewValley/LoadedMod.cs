using gAyPI.Manipulation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley
{
    public struct LoadedMod
    {
        public object instance;
        public Mod annotation;
        public Dictionary<Type, List<MethodInfo>> callMap;

        public LoadedMod(object instance, Mod annotation, Dictionary<Type, List<MethodInfo>> callMap)
        {
            this.instance = instance;
            this.annotation = annotation;
            this.callMap = callMap;
        }

        public string Name { get { return annotation.Name; } }
        public string Author { get { return annotation.Author; } }
        public double Version { get { return annotation.Version; } }

        public void Call<T>(T @event) where T : DetourEvent
        {
            List<MethodInfo> handlers;
            if (callMap.TryGetValue(typeof(T), out handlers))
            {
                foreach (var info in handlers)
                {
                    info.Invoke(instance, new object[] { @event });
                }
            }
        }
    }
}
