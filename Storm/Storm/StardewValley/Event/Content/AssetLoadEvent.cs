using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class AssetLoadEvent : StaticContextEvent
    {

        public Type Type { get; }
        public string Name { get; }
        public ContentManager Manager { get; }

        public AssetLoadEvent(ContentManager manager, Type assetType, string assetName)
        {
            Manager = manager;
            Type = assetType;
            Name = assetName;
        }
    }
}
