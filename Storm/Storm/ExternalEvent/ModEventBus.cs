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

namespace Storm.ExternalEvent
{
    public class ModEventBus
    {
        public List<LoadedMod> mods = new List<LoadedMod>();

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
                    Logging.DebugLogs("[{0}] Mod {1} threw the error {2} ... unloading mod", GetType().Name, lm.Name, e.ToString());
                    lm.Enabled = false;
                }
            }
        }
    }
}