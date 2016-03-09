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
    public interface InventoryPageAccessor : ClickableMenuAccessor
    {
        InventoryMenuAccessor _GetInventory();
        void _SetInventory(InventoryMenuAccessor val);

        string _GetDescriptionText();
        void _SetDescriptionText(string val);

        string _GetHoverText();
        void _SetHoverText(string val);

        string _GetDescriptionTitle();
        void _SetDescriptionTitle(string val);

        string _GetHoverTitle();
        void _SetHoverTitle(string val);

        ItemAccessor _GetHeldItem();
        void _SetHeldItem(ItemAccessor val);

        ItemAccessor _GetHoveredItem();
        void _SetHoveredItem(ItemAccessor val);

        IList _GetEquipmentIcons();
        void _SetEquipmentIcons(IList val);

        float _GetTrashCanLidRotation();
        void _SetTrashCanLidRotation(float val);

        string _GetHorseName();
        void _SetHorseName(string val);
    }
}