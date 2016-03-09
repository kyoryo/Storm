using Microsoft.Xna.Framework.Content;
using Storm.Manipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley
{
    class StormContentManager : ContentManager
    {
        public StormContentManager(IServiceProvider provider) : base(provider)
        {
        }

        public StormContentManager(IServiceProvider provider, string rootDirectory) : base(provider, rootDirectory)
        {
        }

        public override T Load<T>(string assetName)
        {
            DetourEvent @event = StaticGameContext.ContentLoadCallback(this, typeof(T), assetName);
            if (@event.ReturnValue != null)
            {
                return (T)@event.ReturnValue;
            }
            return base.Load<T>(assetName);
        }

        public override void Unload()
        {
            StaticGameContext.ManagerUnloadCallback(this);
            base.Unload();
        }
    }
}
