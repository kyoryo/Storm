namespace Storm.StardewValley.Event.Game
{
    public class ShowRedMessageEvent : StaticContextEvent
    {
        public string Message { get; }

        public ShowRedMessageEvent(string message)
        {
            Message = message;
        }
    }
}
