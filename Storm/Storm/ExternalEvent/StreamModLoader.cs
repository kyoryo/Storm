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

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Storm.ExternalEvent
{
    public class StreamModLoader : AssemblyModLoader, IDisposable
    {
        private readonly Stream strum;

        public StreamModLoader(Stream strum)
        {
            this.strum = strum;
        }

        public void Dispose()
        {
            strum.Close();
        }

        public override List<LoadedMod> Load()
        {
            //var reader = new StreamReader(strum);
            //var result = LoadModFromAssembly(Assembly.Load(reader.ReadToEnd()));
            //reader.Close();
            //return result;
            return null; // iou a StreamModLoader - Handsome Matt
        }
    }
}