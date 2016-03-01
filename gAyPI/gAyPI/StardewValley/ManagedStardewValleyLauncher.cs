using gAyPI.Manipulation;
using gAyPI.StardewValley.Accessor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley
{
    public class ManagedStardewValleyLauncher
    {
        private Stream injectorStream;
        private string gamePath;

        public ManagedStardewValleyLauncher(Stream injectorStream, string gamePath)
        {
            this.injectorStream = injectorStream;
            this.gamePath = gamePath;
        }

        public void Launch()
        {
            // force the loading of XNA libraries so we can resolve injection types...
            Type tmp = null;
            tmp = typeof(Vector2);
            tmp = typeof(SpriteBatch);

            var factory = InjectorFactories.Create(InjectorFactoryType.Cecil, gamePath);

            var ctx = factory.ParseOfType(DataFormat.Json, injectorStream);
            if (factory is CecilInjectorFactory)
            {
                var casted = factory as CecilInjectorFactory;
                ctx.Injectors.Add(new CecilRewriteEntryInjector(casted.Self, casted.CecilAssembly, new RewriteEntryInjectorParams()));
            }
            ctx.Injectors.ForEach(injector => injector.Inject());

            var assembly = ctx.GetConcreteAssembly();
            var entry = assembly.EntryPoint;
            var entryType = entry.DeclaringType;
            var constructor = entryType.GetConstructor(new Type[0]);
            // we're using the entry point class as our static accessor stub, so get ourselves an instance here
            //
            // also important to note that by default, the entry type is a static class, with no constructor
            // it's up to whatever is handling the injection to modify that class!
            StaticGameContext.Root = (ProgramAccessor)constructor.Invoke(new object[0]);

            entry.Invoke(null, new object[] { new string[] { } });
        }
    }
}
