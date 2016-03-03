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

            var launcher = new ManagedStardewValleyLauncher(new FileStream("..\\..\\..\\..\\Dependencies\\injectors-1.02.json", FileMode.Open), "Stardew Valley.exe");
            launcher.Launch();

            Console.ReadKey();
        }
    }
}
