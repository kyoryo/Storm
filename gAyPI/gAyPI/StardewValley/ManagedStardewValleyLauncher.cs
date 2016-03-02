using Castle.DynamicProxy;
using gAyPI.Manipulation;
using gAyPI.StardewValley.Accessor;
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

            new Thread(() => entry.Invoke(null, new object[] { new string[] { } })).Start();
        }
    }
}
