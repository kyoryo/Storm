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
using Storm.Manipulation;

namespace Storm.ExternalEvent
{
    public class ModEventBus
    {
        private readonly Dictionary<Type, List<ReceiverSwitch>> receivers = new Dictionary<Type, List<ReceiverSwitch>>();
        public List<LoadedMod> mods = new List<LoadedMod>();

        private void AddReceiver(LoadedMod parent, Type eventType, MethodInfo receiver, int priority)
        {
            List<ReceiverSwitch> list;
            if (!receivers.TryGetValue(eventType, out list))
            {
                list = new List<ReceiverSwitch>();
                receivers.Add(eventType, list);
            }

            var idx = -1;
            for (var i = 0; i < list.Count; i++)
            {
                if (priority > list[i].priority)
                {
                    idx = i;
                    break;
                }
            }

            var @switch = new ReceiverSwitch {mod = parent, info = receiver, priority = priority, enabled = true};

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

        public void Fire<T>(string name, T val) where T : DetourEvent
        {
            for (var i = 0; i < mods.Count; i++)
            {
                var lm = mods[i];
                try
                {
                    lm.Fire(name, val);
                }
                catch (Exception e)
                {
                    Logging.DebugLogs("[{0}] Mod {1} threw the error {2} ... unloading mod", GetType().Name, lm.Name, e.ToString());
                    lm.Enabled = false;
                }
            }
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