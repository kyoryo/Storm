using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using gAyPI.Manipulation;
using System.IO;

namespace gAyPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Logging.Log = (msg) => Console.WriteLine(msg);

            var factory = InjectorFactories.Create(InjectorFactoryType.Cecil, "Stardew Valley.exe");
            using (var stream = new FileStream("C:\\Users\\Cody\\Desktop\\test_injectors.json", FileMode.Open))
            {
                var ctx = factory.ParseOfType(DataFormat.Json, stream);
                ctx.Injectors.ForEach(injector => injector.Inject());

                var launcher = GameLauncherFactory.Create(GameLauncherType.StardewValley, ctx.GetConcreteAssembly());
                launcher.Launch();
            }
            Console.ReadKey();
        }
    }
}
