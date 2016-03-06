using System;

namespace Storm.StardewValley.Event.Game
{
    public class ClientSizeChangedEvent : StaticContextEvent
    {
        public object Sender { get; }
        public EventArgs E { get; }

        public ClientSizeChangedEvent(object sender, EventArgs e)
        {
            Sender = sender;
            E = e;
        }
    }
}
