using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event.Farmer
{
    public class FarmerCollideWithEvent : StaticContextEvent
    {
        public Object CollisionObject { get; }

        public FarmerCollideWithEvent(ObjectAccessor collisionObject)
        {
            CollisionObject = new Object(StaticGameContext.WrappedGame, collisionObject);
        }
    }
}
