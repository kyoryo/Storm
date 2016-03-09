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

using System.Collections;

namespace Storm.StardewValley.Accessor
{
    public interface InventoryMenuAccessor : ClickableMenuAccessor
    {
        ItemAccessor _GetItemAt(int mouesX, int mouseY);

        string _GetHoverText();
        void _SetHoverText(string val);

        string _GetHoverTitle();
        void _SetHoverTitle(string val);

        string _GetDescriptionTitle();
        void _SetDescriptionTitle(string val);

        string _GetDescriptionText();
        void _SetDescriptionText(string val);

        IList _GetInventory();
        void _SetInventory(IList val);

        IList _GetActualInventory();
        void _SetActualInventory(IList val);

        bool _GetPlayerInventory();
        void _SetPlayerInventory(bool val);

        bool _GetDrawSlots();
        void _SetDrawSlots(bool val);

        bool _GetShowGrayedOutSlots();
        void _SetShowGrayedOutSlots(bool val);

        int _GetCapacity();
        void _SetCapacity(int val);

        int _GetRows();
        void _SetRows(int val);

        int _GetHorizontalGap();
        void _SetHorizontalGap(int val);

        int _GetVerticalGap();
        void _SetVerticalGap(int val);
    }
}