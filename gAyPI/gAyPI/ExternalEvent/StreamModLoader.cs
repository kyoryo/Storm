using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.ExternalEvent
{
    public class StreamModLoader : AssemblyModLoader, IDisposable
    {
        private Stream strum;

        public StreamModLoader(Stream strum)
        {
            this.strum = strum;
        }

        public override List<LoadedMod> Load()
        {
            var reader = new StreamReader(strum);
            var result = new List<LoadedMod>();
            LoadModsFromAssembly(Assembly.Load(reader.ReadToEnd()), result);
            return result;
        }

        public void Dispose()
        {
            strum.Close();
        }
    }
}
