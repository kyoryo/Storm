using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface ClickableTextureComponentAccessor : ClickableComponentAccessor
    {
        Microsoft.Xna.Framework.Graphics.Texture2D _GetTexture();
        void _SetTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        Microsoft.Xna.Framework.Rectangle _GetSourceRect();
        void _SetSourceRect(Microsoft.Xna.Framework.Rectangle val);

        float _GetBaseScale();
        void _SetBaseScale(float val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        bool _GetDrawLabel();
        void _SetDrawLabel(bool val);

        bool _GetDrawShadow();
        void _SetDrawShadow(bool val);

    }
}
