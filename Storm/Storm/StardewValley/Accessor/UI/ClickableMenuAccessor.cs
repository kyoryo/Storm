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

using Microsoft.Xna.Framework.Graphics;

namespace Storm.StardewValley.Accessor
{
    public interface ClickableMenuAccessor
    {
        int _GetBorderWidth();
        void _SetBorderWidth(int val);

        int _GetTabYPositionRelativeToMenuY();
        void _SetTabYPositionRelativeToMenuY(int val);

        int _GetSpaceToClearTopBorder();
        void _SetSpaceToClearTopBorder(int val);

        int _GetSpaceToClearSideBorder();
        void _SetSpaceToClearSideBorder(int val);

        int _GetWidth();
        void _SetWidth(int val);

        int _GetHeight();
        void _SetHeight(int val);

        int _GetXPositionOnScreen();
        void _SetXPositionOnScreen(int val);

        int _GetYPositionOnScreen();
        void _SetYPositionOnScreen(int val);

        int _GetCurrentRegion();
        void _SetCurrentRegion(int val);

        Texture2D _GetHoverBox();
        void _SetHoverBox(Texture2D val);

        ClickableTextureComponentAccessor _GetUpperRightCloseButton();
        void _SetUpperRightCloseButton(ClickableTextureComponentAccessor val);

        bool _GetDestroy();
        void _SetDestroy(bool val);

        bool _GetGamePadControlsImplemented();
        void _SetGamePadControlsImplemented(bool val);

        void _ExitThisMenu(bool playSound);
    }
}