using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface BillboardAccessor : ClickableMenuAccessor
    {
        Microsoft.Xna.Framework.Graphics.Texture2D _GetBillboardTexture();
        void _SetBillboardTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        bool _GetDailyQuestBoard();
        void _SetDailyQuestBoard(bool val);

        ClickableComponentAccessor _GetAcceptQuestButton();
        void _SetAcceptQuestButton(ClickableComponentAccessor val);

        System.Collections.IList _GetCalendarDays();
        void _SetCalendarDays(System.Collections.IList val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

    }
}
