using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            string[] files = Directory.GetFiles(path, "*.dll");
            foreach (var str in files)
            {
                var asm = Assembly.LoadFile(str);
                foreach (var mod in asm.Modules)
                {
                    mod.CustomAttributes.SingleOrDefault(t => t.AttributeType == typeof (Mod));
                }
            }
        }
    }
}
