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
using System.Reflection;

namespace Storm.ExternalEvent
{
    public abstract class AssemblyModLoader : ModLoader
    {
        public abstract List<LoadedMod> Load();

        protected List<AssemblyMod> LoadModsFromAssembly(Assembly assembly)
        {
            var result = new List<AssemblyMod>();
            try
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
                            Logging.DebugLog("Invalid handler on " + mod.FullName + " " + handler.Name + " " + ReflectionUtils.DescriptionOf(handler));
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

                    result.Add(new AssemblyMod
                    {
                        Instance = mod.GetConstructor(Type.EmptyTypes).Invoke(null),
                        CallMap = map
                    });
                }
            }
            catch (Exception e)
            {
                Logging.Logs("[{0}] Failed to load mods from assembly {1} due to error {2}", GetType().Name, assembly.FullName, e.ToString());
            }
            return result;
        }
    }
}