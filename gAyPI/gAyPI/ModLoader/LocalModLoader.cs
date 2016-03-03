using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using gAyPI.StardewValley;

namespace gAyPI.ModLoader
{
    public class LocalModLoader : IModLoader
    { 
        private string path;

        public LocalModLoader(string path = "./")
        {
            this.path = path;
        }

        public List<Assembly> Load()
        {
            string[] dirs = Directory.GetDirectories(path);
            List<Assembly> result = new List<Assembly>();
            foreach (var str in dirs)
            {
                LoadMod(result, str);
            }
            return result;
        }

        private void LoadMod(List<Assembly> result, string path)
        {
            var files = Directory.GetFiles(path, "*.dll");
            result.AddRange(from str in files select Assembly.LoadFile(str) into asm from mod in asm.Modules from type in mod.GetTypes() where type.CustomAttributes.FirstOrDefault(t => t.AttributeType == typeof (Mod)) != null select asm);
        }
    }
}
