using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Storm.ExternalEvent;
using Storm.StardewValley;
using Storm.StardewValley.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceDumper
{
    [Mod]
    public class ResourceExample : DiskResource
    {
        [Subscribe]
        public void onAssetLoad(AssetLoadEvent @event)
        {
            if (@event.Name == "Minigames\\TitleButtons")
            {
                var path = Path.Combine(PathOnDisk, "TitleButtons.png");
                @event.ReturnValue = @event.Root.LoadResource(path);
                Console.WriteLine(@event.ReturnValue);
            }
        }
    }
}
