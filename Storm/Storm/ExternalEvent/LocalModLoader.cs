/*
    Copyright 2016 Cody R. (Demmonic)

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

using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Storm.ExternalEvent
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
                Logging.DebugLog("Loading mod from " + file);
                var loaded = LoadModsFromAssembly(Assembly.LoadFile(file));
                loaded.ForEach(m => m.LoadDirectory = file);
                result.AddRange(loaded);
            }
        }
    }
}
