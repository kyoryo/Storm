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
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.Manipulation.Cecil;
using Storm.StardewValley.Accessor;
using Rectangle = xTile.Dimensions.Rectangle;
using Storm.StardewValley.Proxy;

namespace Storm.StardewValley
{
    /// <summary>
    ///     Handles managed injection & launching of Stardew Valley
    /// </summary>
    public class ManagedStardewValleyLauncher
    {
        public ManagedStardewValleyLauncher(string injectorsPath, string gamePath, bool debug = false)
        {
            InjectorsPath = injectorsPath;
            GamePath = gamePath;
            Debug = debug;
        }

        /// <summary>
        ///     The file path to the injectors json.
        /// </summary>
        public string InjectorsPath { get; set; }

        /// <summary>
        ///     The file  path to the game executable.
        /// </summary>
        public string GamePath { get; set; }

        /// <summary>
        ///     If Storm is in debug mode or not.
        /// </summary>
        public bool Debug { get; set; }

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
                ctx.Injectors.ForEach(injector => injector.Init());
                ctx.Injectors.ForEach(injector => injector.Inject());
                if (Debug)
                {
                    if (factory is CecilInjectorFactory)
                    {
                        var casted = factory as CecilInjectorFactory;
                        using (var fs = new FileStream("Modified-Game.exe", FileMode.Create, FileAccess.Write))
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
            StaticGameContext.Root = (ProgramAccessor) constructor.Invoke(new object[0]);
            StaticGameContext.ToolType = InjectorMetaData.AccessorToGameType<ToolAccessor>(ctx.Injectors, assembly);
            StaticGameContext.ToolFactory = new ToolInterceptorDelegateFactory(StaticGameContext.WrappedGame,
                InjectorMetaData.NameOfMethod<ToolAccessor>(ctx.Injectors, "DrawInMenu"),
                InjectorMetaData.NameOfMethod<ToolAccessor>(ctx.Injectors, "BeginUsing"));

            var eventBus = new ModEventBus();
            if (!Directory.Exists(StormAPI.ModsPath))
                Directory.CreateDirectory(StormAPI.ModsPath);

            var modLoader = new LocalModLoader(StormAPI.ModsPath);
            var mods = modLoader.Load();
            foreach (var mod in mods)
                eventBus.AddReceiver(mod);

            StaticGameContext.EventBus = eventBus;
        }

        public void Launch()
        {
            // force the loading of dependencies so we can resolve injection types...
            Type tmp = null;
            tmp = typeof (Vector2);
            tmp = typeof (SpriteBatch);
            tmp = typeof (AudioEngine);
            tmp = typeof (GraphicsDeviceManager);
            tmp = typeof (Keyboard);
            tmp = typeof (Rectangle);

            var ctx = Inject();
            InitializeStaticContext(ctx);

            var assembly = ctx.GetConcreteAssembly();
            assembly.EntryPoint.Invoke(null, new object[] {new string[] {}});
        }
    }
}