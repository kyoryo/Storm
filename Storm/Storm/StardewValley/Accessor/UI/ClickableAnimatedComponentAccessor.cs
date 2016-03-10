using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface ClickableAnimatedComponentAccessor : ClickableComponentAccessor
    {
        TempAnimatedSpriteAccessor _GetSprite();
        void _SetSprite(TempAnimatedSpriteAccessor val);

        Microsoft.Xna.Framework.Rectangle _GetSourceRect();
        void _SetSourceRect(Microsoft.Xna.Framework.Rectangle val);

        float _GetBaseScale();
        void _SetBaseScale(float val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        bool _GetDrawLabel();
        void _SetDrawLabel(bool val);
    }
}
