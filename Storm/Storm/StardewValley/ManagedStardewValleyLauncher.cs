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

        private ModEventBus EventBus { get; } = new ModEventBus();

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
            StaticGameContext.ObjectType = InjectorMetaData.AccessorToGameType<ObjectAccessor>(ctx.Injectors, assembly);
            StaticGameContext.BillboardType = InjectorMetaData.AccessorToGameType<BillboardAccessor>(ctx.Injectors, assembly);

            var toolFactory = new MappedInterceptorFactory<ToolDelegate>();
            toolFactory.Map(typeof (ToolAccessor), typeof (ToolDelegate), ctx.Injectors);
            StaticGameContext.ToolFactory = toolFactory;

            var objectFactory = new MappedInterceptorFactory<ObjectDelegate>();
            objectFactory.Map(typeof (ObjectAccessor), typeof (ObjectDelegate), ctx.Injectors);
            StaticGameContext.ObjectFactory = objectFactory;

            var billboardFactory = new MappedInterceptorFactory<BillboardDelegate>();
            billboardFactory.Map(typeof (BillboardAccessor), typeof (BillboardDelegate), ctx.Injectors);
            StaticGameContext.BillboardFactory = billboardFactory;

            var clickableMenuFactory = new MappedInterceptorFactory<ClickableMenuDelegate>();
            clickableMenuFactory.Map(typeof (ClickableMenuAccessor), typeof (ClickableMenuDelegate), ctx.Injectors);
            StaticGameContext.ClickableMenuFactory = clickableMenuFactory;

            StaticGameContext.EventBus = EventBus;
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private void ResolveDependencies()
        {
            typeof (Vector2).GetType();
            typeof (SpriteBatch).GetType();
            typeof (AudioEngine).GetType();
            typeof (GraphicsDeviceManager).GetType();
            typeof (Keyboard).GetType();
            typeof (Rectangle).GetType();
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
            assembly.EntryPoint.Invoke(null, new object[] {new string[] {}});
        }
    }
}