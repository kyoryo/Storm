using Castle.DynamicProxy;
using Storm.Manipulation;
using Storm.ExternalEvent;
using Storm.StardewValley.Accessor;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Storm.Manipulation.Cecil;

namespace Storm.StardewValley
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
            // force the loading of dependencies so we can resolve injection types...
            Type tmp = null;
            tmp = typeof(Microsoft.Xna.Framework.Vector2);
            tmp = typeof(Microsoft.Xna.Framework.Graphics.SpriteBatch);
            tmp = typeof(Microsoft.Xna.Framework.GraphicsDeviceManager);
            tmp = typeof(xTile.Dimensions.Rectangle);

            var factory = InjectorFactories.Create(InjectorFactoryType.Cecil, gamePath);
            var ctx = factory.ParseOfType(DataFormat.Json, injectorStream);
            if (factory is CecilInjectorFactory)
            {
                var casted = factory as CecilInjectorFactory;
                ctx.Injectors.Add(new CecilRewriteEntryInjector(casted.SelfAssembly, casted.GameAssembly, new RewriteEntryInjectorParams()));
            }
            ctx.Injectors.ForEach(injector => injector.Inject());

            var assembly = ctx.GetConcreteAssembly();
            var entry = assembly.EntryPoint;
            var entryType = entry.DeclaringType;
            var constructor = entryType.GetConstructor(new Type[0]);

            StaticGameContext.Assembly = assembly;
            StaticGameContext.Root = (ProgramAccessor)constructor.Invoke(new object[0]);
            StaticGameContext.ToolType = InjectorMetaData.AccessorToGameType<ToolAccessor>(ctx.Injectors, assembly);
            StaticGameContext.ToolFactory = new ToolInterceptorDelegateFactory(InjectorMetaData.NameOfMethod<ToolAccessor>(ctx.Injectors, "GetName"));

            var modFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "storm-mods\\");
            var eventBus = new ModEventBus();
            if (!Directory.Exists(modFolder))
            {
                Directory.CreateDirectory(modFolder);
            }

            var modLoader = new LocalModLoader(modFolder);
            var mods = modLoader.Load();
            foreach (var mod in mods)
            {
                eventBus.AddReceiver(mod);
            }
            StaticGameContext.EventBus = eventBus;
            
            new Thread(() => entry.Invoke(null, new object[] { new string[] { } })).Start();
        }
    }
}
