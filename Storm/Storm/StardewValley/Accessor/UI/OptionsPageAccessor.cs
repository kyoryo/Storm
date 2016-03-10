/*
    Copyright 2016 Cody R. (Demmonic)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface OptionsPageAccessor : ClickableMenuAccessor
    {
        System.String _GetDescriptionText();
        void _SetDescriptionText(System.String val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        System.Collections.IList _GetOptionSlots();
        void _SetOptionSlots(System.Collections.IList val);

        int _GetCurrentItemIndex();
        void _SetCurrentItemIndex(int val);

        ClickableTextureComponentAccessor _GetUpArrow();
        void _SetUpArrow(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetDownArrow();
        void _SetDownArrow(ClickableTextureComponentAccessor val);

        ClickableTextureComponentAccessor _GetScrollBar();
        void _SetScrollBar(ClickableTextureComponentAccessor val);

        bool _GetScrolling();
        void _SetScrolling(bool val);

        System.Collections.IList _GetOptions();
        void _SetOptions(System.Collections.IList val);

        Microsoft.Xna.Framework.Rectangle _GetScrollBarRunner();
        void _SetScrollBarRunner(Microsoft.Xna.Framework.Rectangle val);

        int _GetOptionsSlotHeld();
        void _SetOptionsSlotHeld(int val);
    }
}
