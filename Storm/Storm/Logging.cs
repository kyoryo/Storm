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
using Storm.StardewValley;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm
{
    public sealed class Logging
    {
        private Logging() { }

        public delegate void Logger(string msg);

        public static Logger Log = (s) => { };
        public static Logger DebugLog = (s) => { };

        public static UnhandledExceptionEventHandler UnhandledExceptionHandler = (s, e) =>
        {
            var @out = StormAPI.GetResource("crash_log.txt");
            var sr = new StreamWriter(@out, true);
            sr.WriteLine(e.ToString());
            sr.Close();
        };
    }
}
