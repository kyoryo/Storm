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

using System.Collections.Generic;
using Storm.Manipulation;
using System;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Event;
using System.Reflection;

namespace Storm.ExternalEvent
{
    public class ModEventBus
    {
        public List<LoadedMod> mods = new List<LoadedMod>();
        private Dictionary<Type, List<ReceiverSwitch>> receivers = new Dictionary<Type, List<ReceiverSwitch>>();

        private void AddReceiver(LoadedMod parent, Type eventType, MethodInfo receiver, int priority)
        {
            List<ReceiverSwitch> list;
            if (!receivers.TryGetValue(eventType, out list))
            {
                list = new List<ReceiverSwitch>();
                receivers.Add(eventType, list);
            }

            var idx = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (priority > list[i].priority)
                {
                    idx = i;
                    break;
                }
            }

            var @switch = new ReceiverSwitch
            {
                mod = parent,
                info = receiver,
                priority = priority,
                enabled = true
            };

            if (idx == -1) list.Add(@switch);
            else list.Insert(idx, @switch);
        }

        public void AddReceiver(LoadedMod mod)
        {
            mods.Add(mod);
        }

        public void RemoveReceiver(LoadedMod mod)
        {
            mods.Remove(mod);
        }

        public void Fire<T>(T val) where T : DetourEvent
        {
            for (int i = 0; i < mods.Count; i++)
            {
                var lm = mods[i];
                try
                {
                    lm.Fire(val);
                }
                catch (Exception e)
                {
                    Logging.DebugLogs("[{0}] Mod {1} threw the error {2} ... unloading mod", GetType().Name, lm.Name,
                        e.ToString());
                    lm.Enabled = false;
                }
            }
        }

        public object MapContent(AssetLoadEvent @event)
        {
            for (int i = 0; i < mods.Count; i++)
            {
                var lm = mods[i];
                var props = lm.Properties;
                if (props == null || props.Path == null ||
                    props.Resources == null || props.Resources[@event.Name] == null)
                {
                    continue;
                }
                var mapped = MapContent(props, @event);
                if (mapped != null)
                {
                    return mapped;
                }
            }
            return null;
        }

        private object MapContent(dynamic props, AssetLoadEvent @event)
        {
            var path = props.Path.ToString();
            var resource = Path.Combine(path, props.Resources[@event.Name].ToString()).ToString();
            if (!File.Exists(resource))
            {
                Console.WriteLine("Missing resource map:" + resource);
                return null;
            }
            try
            {
                if (@event.Type == typeof(Texture2D))
                {
                    return @event.Root.LoadResource(resource);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to map:" + @event.Name + " To:" + resource);
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        private struct ReceiverSwitch
        {
            public LoadedMod mod;
            public MethodInfo info;
            public int priority;
            public bool enabled;
        }
    }
}
