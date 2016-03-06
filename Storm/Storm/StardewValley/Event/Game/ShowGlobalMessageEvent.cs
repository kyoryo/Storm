namespace Storm.StardewValley.Event.Game
{
    public class ShowGlobalMessageEvent : StaticContextEvent
    {
        public string Message { get; }

        public ShowGlobalMessageEvent(string message)
        {
            Message = message;
        }
    }
}
