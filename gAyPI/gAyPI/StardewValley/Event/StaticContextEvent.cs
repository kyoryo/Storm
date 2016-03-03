using gAyPI.ExternalEvent;
using gAyPI.Manipulation;
using gAyPI.StardewValley.Accessor;
using gAyPI.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley.Event
{
    public class StaticContextEvent : DetourEvent
    {
        public Assembly GameAssembly { get; set; }
        public StaticContext Root { get; set; }
        public ModEventBus EventBus { get; set; }

        public StaticContextEvent()
        {
            GameAssembly = StaticGameContext.Assembly;
            Root = StaticGameContext.WrappedGame;
            EventBus = StaticGameContext.EventBus;
        }
    }
}
