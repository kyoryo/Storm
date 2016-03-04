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

                              .       .
                         / `.   .' \
                 .---.  <    > <    >  .---.
                 |    \  \ - ~ ~ - /  /    |
                  ~-..-~             ~-..-~
              \~~~\.'                    `./~~~/
    .-~~^-.    \__/                        \__/
  .'  O    \     /               /       \  \
 (_____,    `._.'               |         }  \/~~~/
  `----.          /       }     |        /    \__/
        `-.      |       /      |       /      `. ,~~|
            ~-.__|      /_ - ~ ^|      /- _      `..-'   f: f:
                 |     /        |     /     ~-.     `-. _||_||_
                 |_____|        |_____|         ~ - . _ _ _ _ _>

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Storm.Manipulation;
using System.IO;
using Storm.StardewValley;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storm.ExternalEvent;
using System.Diagnostics;

namespace Storm
{
    class Program
    {
        static void Main(string[] args)
        {
            Logging.Log = (msg) => Console.WriteLine(msg);
            Logging.DebugLog = (msg) => Debug.WriteLine(msg);

            FileStream injectStream = null;
            try {
                injectStream = new FileStream("injectors-1.02.json", FileMode.Open, FileAccess.Read);

                var launcher = new ManagedStardewValleyLauncher(injectStream, "Stardew Valley.exe");
                launcher.Launch();
            }
            catch (Exception ex)
            {
                Logging.Log(ex.Message);
            }
            finally
            {
                if (injectStream != null)
                    injectStream.Close();
            }
        }
    }
}
