using Storm.Manipulation;
using Storm.StardewValley;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.ExternalEvent
{
    public class ModEventBus
    {
        private List<LoadedMod> mods = new List<LoadedMod>();

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
            foreach (var mod in mods)
            {
                mod.Call<T>(val);
            }
        }
    }
}
