using gAyPI.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public sealed class StardewValleyGameLauncher : GameLauncher
    {
        private Assembly assembly;

        public StardewValleyGameLauncher(Assembly assembly)
        {
            this.assembly = assembly;
        }

        public void Launch()
        {
            CallbackTest.entry = (ProgramAccessor) assembly.EntryPoint.GetType().GetConstructors()[0].Invoke(new object[0]);
            assembly.EntryPoint.Invoke(null, new object[] { new string[] { } });
        }
    }
}
