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

        private InjectionFactoryContext Inject()
        {
            var factory = InjectorFactories.Create(InjectorFactoryType.Cecil, gamePath);
            var ctx = factory.ParseOfType(DataFormat.Json, injectorStream);
            if (factory is CecilInjectorFactory)
            {
                var casted = factory as CecilInjectorFactory;
                ctx.Injectors.Add(new CecilRewriteEntryInjector(casted.SelfAssembly, casted.GameAssembly, new RewriteEntryInjectorParams()));
            }
            ctx.Injectors.ForEach(injector => injector.Inject());
            return ctx;
        }

        private void InitializeStaticContext(InjectionFactoryContext ctx)
        {
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
        }

        public void Launch()
        {
            // force the loading of dependencies so we can resolve injection types...
            Type tmp = null;
            tmp = typeof(Microsoft.Xna.Framework.Vector2);
            tmp = typeof(Microsoft.Xna.Framework.Graphics.SpriteBatch);
            tmp = typeof(Microsoft.Xna.Framework.GraphicsDeviceManager);
            tmp = typeof(xTile.Dimensions.Rectangle);

            var ctx = Inject();
            InitializeStaticContext(ctx);

            var assembly = ctx.GetConcreteAssembly();
            assembly.EntryPoint.Invoke(null, new object[] { new string[] { } });
        }
    }
}
