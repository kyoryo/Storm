using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using gAyPI.StardewValley;
using gAyPI.StardewValley.Accessor;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace gAyPI.StardewValley
{
    public sealed class StaticGameContext
    {
        private StaticGameContext() { }

        private static ProgramAccessor root = null;

        public static ProgramAccessor Root
        {
            set { root = value; }
        }

        public static void DrawLastCallback()
        {
            var batch = root.GetGame().GetSpriteBatch();
            var font = root.GetGame().GetSmoothFont();
            batch.DrawString(font, "gAyPI - Draw Hook?", new Microsoft.Xna.Framework.Vector2(16f, 16f), Color.DarkRed);
        }
    }
}
