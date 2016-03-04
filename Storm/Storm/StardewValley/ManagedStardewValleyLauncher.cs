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
        public string InjectorsPath { get; set; }
        public string GamePath { get; set; }
        public bool Debug { get; set; }

        public ManagedStardewValleyLauncher(string injectorsPath, string gamePath, bool debug = false)
        {
            this.InjectorsPath = injectorsPath;
            this.GamePath = gamePath;
            this.Debug = debug;
        }

        private InjectionFactoryContext Inject()
        {
            using (var injectorStream = new FileStream(InjectorsPath, FileMode.Open, FileAccess.Read))
            {
                var factory = InjectorFactories.Create(InjectorFactoryType.Cecil, GamePath);
                var ctx = factory.ParseOfType(DataFormat.Json, injectorStream);
                if (factory is CecilInjectorFactory)
                {
                    var casted = factory as CecilInjectorFactory;
                    ctx.Injectors.Add(new CecilRewriteEntryInjector(casted.SelfAssembly, casted.GameAssembly, new RewriteEntryInjectorParams()));
                }
                ctx.Injectors.ForEach(injector => injector.Inject());
                if (Debug)
                {
                    if (factory is CecilInjectorFactory)
                    {
                        var casted = factory as CecilInjectorFactory;
                        using (var fs = new FileStream("Modified-Game.exe", FileMode.Create, FileAccess.Read))
                        {
                            casted.WriteModifiedAssembly(fs);
                        }
                    }
                }

                return ctx;
            }
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
            
            var eventBus = new ModEventBus();
            if (!Directory.Exists(StormAPI.stormModsPath))
            {
                Directory.CreateDirectory(StormAPI.stormModsPath);
            }

            var modLoader = new LocalModLoader(StormAPI.stormModsPath);
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
