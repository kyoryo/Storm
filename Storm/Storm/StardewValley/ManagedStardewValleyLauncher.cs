/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Storm.ExternalEvent;
using Storm.Manipulation;
using Storm.Manipulation.Cecil;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Event;
using Storm.StardewValley.Proxy;
using Rectangle = xTile.Dimensions.Rectangle;
using System.Windows.Forms;

namespace Storm.StardewValley
{
    /// <summary>
    ///     Handles managed injection & launching of Stardew Valley
    /// </summary>
    public class ManagedStardewValleyLauncher
    {
        public ManagedStardewValleyLauncher(string gamePath, bool debug = false)
        {
            GamePath = gamePath;
            Debug = debug;
        }

        /// <summary>
        ///     The file  path to the game executable.
        /// </summary>
        public string GamePath { get; set; }

        /// <summary>
        ///     If Storm is in debug mode or not.
        /// </summary>
        public bool Debug { get; set; }

        private ModEventBus EventBus { get; } = new ModEventBus();

        private InjectionFactoryContext Inject()
        {
            if (!File.Exists(StormAPI.GetResource("interface_injectors.json")))
            {
                MessageBox.Show("Could not find injectors @\n" +
                    StormAPI.GetResource("interface_injectors.json") + " /\n" +
                    StormAPI.GetResource("secondary") + "\\", "Error");

                Environment.Exit(1);
            }

            var factory = InjectorFactories.Create(InjectorFactoryType.Cecil, GamePath);
            var ctx = factory.ParseOfType(DataFormat.Json, StormAPI.GetResource(""));
            if (factory is CecilInjectorFactory)
            {
                var casted = factory as CecilInjectorFactory;
                ctx.Injectors.Add(new CecilRewriteEntryInjector(casted.SelfAssembly, casted.GameAssembly, new RewriteEntryInjectorParams()));
                ctx.Injectors.Add(new CecilInstanceDetourInjector(casted.SelfAssembly, casted.GameAssembly, new ConstructorReplacerParams
                {
                    FromClass = "Microsoft.Xna.Framework.Content.ContentManager",
                    ToClass = "Storm.StardewValley.StormContentManager"
                }));
            }

            var @event = new PreInjectionEvent(factory, ctx.Injectors);
            EventBus.Fire(@event);

            ctx.Injectors.ForEach(injector => injector.Init());
            ctx.Injectors.ForEach(injector => injector.Inject());
            return ctx;
        }

        private void InitializeStaticContext(InjectionFactoryContext ctx)
        {
            var assembly = ctx.GetConcreteAssembly();
            var entry = assembly.EntryPoint;
            var entryType = entry.DeclaringType;
            var constructor = entryType.GetConstructor(new Type[0]);

            var root = (ProgramAccessor)constructor.Invoke(new object[0]);

            StaticGameContext.Init(assembly, root, EventBus, ctx.Injectors);
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private void ResolveDependencies()
        {
            typeof(Vector2).GetType();
            typeof(SpriteBatch).GetType();
            typeof(AudioEngine).GetType();
            typeof(GraphicsDeviceManager).GetType();
            typeof(Keyboard).GetType();
            typeof(Rectangle).GetType();
        }

        public void Launch()
        {
            ResolveDependencies();

            if (!Directory.Exists(StormAPI.ModsPath))
            {
                Directory.CreateDirectory(StormAPI.ModsPath);
            }
            var modLoader = new LocalModLoader(StormAPI.ModsPath);
            var mods = modLoader.Load();
            foreach (var mod in mods) EventBus.AddReceiver(mod);

            var ctx = Inject();
            InitializeStaticContext(ctx);

            var assembly = ctx.GetConcreteAssembly();
            assembly.EntryPoint.Invoke(null, new object[] { new string[] { } });
        }
    }
}