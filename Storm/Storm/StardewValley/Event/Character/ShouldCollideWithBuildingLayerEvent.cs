using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event.Farmer
{
    public class ShouldCollideWithBuildingLayerEvent : StaticContextEvent
    {
        public GameLocation BuildingLocation { get; }

        public ShouldCollideWithBuildingLayerEvent(GameLocationAccessor gameLocationAccessor)
        {
            BuildingLocation = new GameLocation(StaticGameContext.WrappedGame, gameLocationAccessor);
        }
    }
}
