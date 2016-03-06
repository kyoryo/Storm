using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class TerrainFeature : Wrapper<TerrainFeatureAccessor>
    {
        private StaticContext Parent { get; }
        private TerrainFeatureAccessor accessor;

        public TerrainFeature(StaticContext parent, TerrainFeatureAccessor accessor)
        {
            this.Parent = parent;
            this.accessor = accessor;
        }

        public TerrainFeatureAccessor Expose() => accessor;
    }
}
