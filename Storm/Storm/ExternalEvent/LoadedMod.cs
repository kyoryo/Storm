﻿/*
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
using Storm.Manipulation;

namespace Storm.ExternalEvent
{
    public struct LoadedMod
    {
        public List<AssemblyMod> AssemblyMods;
        public JsonModManifest Manifest;
        public bool Enabled;

        public LoadedMod(JsonModManifest manifest, List<AssemblyMod> mods)
        {
            Manifest = manifest;
            AssemblyMods = mods;
            Enabled = true;
        }

        public string Name
        {
            get { return Manifest.DisplayName; }
        }

        public string Author
        {
            get { return Manifest.Author; }
        }

        public string Description
        {
            get { return Manifest.Description; }
        }

        public string Version
        {
            get { return Manifest.Version; }
        }

        public Dictionary<string, string> Textures
        {
            get { return Manifest.Textures; }
        }

        public void Fire<T>(T @event) where T : DetourEvent
        {
            if (!Enabled) return;
            foreach (var mod in AssemblyMods)
                mod.Fire(@event);
        }
    }
}