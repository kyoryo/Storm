using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class TerrainFeature : Wrapper<TerrainFeatureAccessor>
    {
        private readonly TerrainFeatureAccessor accessor;

        public TerrainFeature(StaticContext parent, TerrainFeatureAccessor accessor)
        {
            Parent = parent;
            this.accessor = accessor;
        }

        private StaticContext Parent { get; }

        public TerrainFeatureAccessor Expose() => accessor;
    }
}