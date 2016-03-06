using System;

namespace Storm.StardewValley.Event.Game
{
    public class GameExitEvent : StaticContextEvent
    {
        public object Sender { get; }
        public EventArgs E { get; }

        public GameExitEvent(object sender, EventArgs e)
        {
            Sender = sender;
            E = e;
        }
    }
}
