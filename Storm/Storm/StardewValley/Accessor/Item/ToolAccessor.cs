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
    public interface ToolAccessor : ItemAccessor
    {
        Microsoft.Xna.Framework.Graphics.Texture2D _GetWeaponsTexture();
        void _SetWeaponsTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        System.String _GetName();
        void _SetName(System.String val);

        System.String _GetDescription();
        void _SetDescription(System.String val);

        int _GetInitialParentTileIndex();
        void _SetInitialParentTileIndex(int val);

        int _GetCurrentParentTileIndex();
        void _SetCurrentParentTileIndex(int val);

        int _GetIndexOfMenuItemView();
        void _SetIndexOfMenuItemView(int val);

        bool _GetStackable();
        void _SetStackable(bool val);

        bool _GetInstantUse();
        void _SetInstantUse(bool val);

        Microsoft.Xna.Framework.Color _GetCopperColor();
        void _SetCopperColor(Microsoft.Xna.Framework.Color val);

        Microsoft.Xna.Framework.Color _GetSteelColor();
        void _SetSteelColor(Microsoft.Xna.Framework.Color val);

        Microsoft.Xna.Framework.Color _GetGoldColor();
        void _SetGoldColor(Microsoft.Xna.Framework.Color val);

        Microsoft.Xna.Framework.Color _GetIridiumColor();
        void _SetIridiumColor(Microsoft.Xna.Framework.Color val);

        int _GetUpgradeLevel();
        void _SetUpgradeLevel(int val);

        int _GetNumAttachmentSlots();
        void _SetNumAttachmentSlots(int val);

        FarmerAccessor _GetLastUser();
        void _SetLastUser(FarmerAccessor val);

        ObjectAccessor[] _GetAttachments();
        void _SetAttachments(ObjectAccessor[] val);
    }
}