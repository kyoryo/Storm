using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Storm.Manipulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.ExternalEvent;

namespace Storm.StardewValley
{
    public static class StormContentManager
    {
        public static T Load<T>(ContentManager manager, string assetName)
        {
            DetourEvent @event = StaticGameContext.ContentLoadCallback(manager, typeof(T), assetName);
            if (@event.ReturnValue != null)
            {
                return (T)@event.ReturnValue;
            }
            return manager.Load<T>(assetName);
        }

        public static void Unload(ContentManager manager)
        {
            StaticGameContext.ManagerUnloadCallback(manager);
            manager.Unload();
        }

        public static Texture2D LookupTexture(List<LoadedMod> mods, string asset)
        {
            foreach (var mod in mods)
            {
                if (mod.Textures != null && mod.Textures.ContainsKey(asset))
                {
                    var path = Path.Combine(mod.Manifest.Path, mod.Textures[asset]);
                    Console.WriteLine(asset + " => " + path);
                    return StaticGameContext.WrappedGame.LoadResource(path);
                }
            }
            return null;
        }
    }
}
