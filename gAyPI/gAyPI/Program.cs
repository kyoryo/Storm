using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gAyPI.Manipulation;
using System.IO;
using gAyPI.StardewValley;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using gAyPI.ModLoader;
using System.Diagnostics;

namespace gAyPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Logging.Log = (msg) => Console.WriteLine(msg);

            var launcher = new ManagedStardewValleyLauncher(new FileStream("C:\\Users\\Cody\\Desktop\\test_injectors.json", FileMode.Open), "Stardew Valley.exe");
            launcher.Launch();

            Console.ReadKey();
        }
    }
}
