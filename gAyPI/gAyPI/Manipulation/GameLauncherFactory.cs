using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Manipulation
{
    public sealed class GameLauncherFactory
    {
        private GameLauncherFactory() { }

        public static GameLauncher Create(GameLauncherType type, Assembly assembly)
        {
            switch (type)
            {
                case GameLauncherType.StardewValleyModBootstrap:
                    return new StardewValleyGameLauncher(assembly);
            }
            throw new NotSupportedException(string.Format("Unsupported type {0}", type));
        }
    }
}
