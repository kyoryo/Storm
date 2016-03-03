using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using gAyPI.StardewValley;
using System.Diagnostics;

namespace gAyPI.ExternalEvent
{
    public class LocalModLoader : AssemblyModLoader
    { 
        private string path;

        public LocalModLoader(string path = "./")
        {
            this.path = path;
        }

        public override List<LoadedMod> Load()
        {
            var dirs = Directory.GetDirectories(path);
            var result = new List<LoadedMod>();
            foreach (var str in dirs)
            {
                LoadMod(result, str);
            }
            return result;
        }

        private void LoadMod(List<LoadedMod> result, string path)
        {
            var files = Directory.GetFiles(path, "*.dll");
            foreach (var file in files)
            {
                LoadModsFromAssembly(Assembly.LoadFile(file), result);
            }
        }
    }
}
