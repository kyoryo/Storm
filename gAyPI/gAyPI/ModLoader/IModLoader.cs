using gAyPI.StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.ModLoader
{
    public interface IModLoader
    {
        List<LoadedMod> Load();
    }
}
