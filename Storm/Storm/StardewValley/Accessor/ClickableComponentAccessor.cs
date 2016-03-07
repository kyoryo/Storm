using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface ClickableComponentAccessor
    {
        Microsoft.Xna.Framework.Rectangle _GetBounds();
        void _SetBounds(Microsoft.Xna.Framework.Rectangle val);

        System.String _GetName();
        void _SetName(System.String val);

        float _GetScale();
        void _SetScale(float val);

        ItemAccessor _GetItem();
        void _SetItem(ItemAccessor val);

        bool _GetVisible();
        void _SetVisible(bool val);

    }
}
