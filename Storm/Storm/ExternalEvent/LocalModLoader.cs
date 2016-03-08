/*
    Copyright 2016 Cody R. (Demmonic), Matt Stevens (Handsome Matt)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Storm.ExternalEvent
{
    public class LocalModLoader : AssemblyModLoader
    {
        private readonly string path;

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
            var manifestPath = Path.Combine(path, "manifest.json");
            var contentPath = Path.Combine(path, "Content");

            /* I thought about allowing mods without manifests, but it's unnecessary */
            /* just include a manifest.json with ur mods gee - Handsome Matt */
            if (!File.Exists(manifestPath))
                return;

            var manifest = JsonConvert.DeserializeObject<Json.JsonModManifest>(File.ReadAllText(manifestPath));

            var dllPath = string.Empty;
            if (!string.IsNullOrEmpty(manifest.AssemblyFileName))
                dllPath = Path.Combine(path, (string)manifest.AssemblyFileName);

            /* if we have an assembly to load, let's do it */
            List<AssemblyMod> assemblyMods = new List<AssemblyMod>();
            if (!string.IsNullOrEmpty(dllPath) && File.Exists(dllPath))
            {
                var loaded = LoadModsFromAssembly(Assembly.LoadFile(dllPath));
                loaded.ForEach(m => m.LoadDirectory = path);

                assemblyMods.AddRange(loaded);
            }

            if (Directory.Exists(contentPath))
            {
                /* do our custom content handlers */
            }

            LoadedMod mod = new LoadedMod(manifest, assemblyMods);
            result.Add(mod);

            Logging.DebugLog(string.Format("Loaded {0} {2} by {1}", mod.Name, mod.Author, mod.Version));
        }
    }
}