using Microsoft.Xna.Framework;

namespace Storm.StardewValley.Event.Game
{
    public class UpdateTitleScreenEvent : StaticContextEvent
    {
        public GameTime GameTime { get; }

        public UpdateTitleScreenEvent(GameTime gameTime)
        {
            GameTime = gameTime;
        }
    }
}
