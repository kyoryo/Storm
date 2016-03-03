using Storm.StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Storm.ExternalEvent
{
    public interface ModLoader
    {
        List<LoadedMod> Load();
    }
}
