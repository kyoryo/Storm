using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley
{
    public static class StormAPI
    {
        public static readonly string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\";
        public static readonly string stardewPath = appDataPath + "StardewValley\\";
        public static readonly string stormPath = stardewPath + "Storm\\";
        public static readonly string stormModsPath = stormPath + "Mods\\";

        public static string GetResource(string file)
        {
            if (!Directory.Exists(stormPath))
            {
                Directory.CreateDirectory(stormPath);
            }
            return Path.Combine(stormPath, file);
        }
    }
}
