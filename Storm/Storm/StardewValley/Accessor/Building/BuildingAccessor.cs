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

namespace Storm.StardewValley.Accessor
{
    public interface BuildingAccessor
    {
        GameLocationAccessor _GetIndoors();
        void _SetIndoors(GameLocationAccessor val);

        Microsoft.Xna.Framework.Graphics.Texture2D _GetTexture();
        void _SetTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        int _GetTileX();
        void _SetTileX(int val);

        int _GetTileY();
        void _SetTileY(int val);

        int _GetTilesWide();
        void _SetTilesWide(int val);

        int _GetTilesHigh();
        void _SetTilesHigh(int val);

        int _GetMaxOccupants();
        void _SetMaxOccupants(int val);

        int _GetCurrentOccupants();
        void _SetCurrentOccupants(int val);

        int _GetDaysOfConstructionLeft();
        void _SetDaysOfConstructionLeft(int val);

        int _GetDaysUntilUpgrade();
        void _SetDaysUntilUpgrade(int val);

        System.String _GetBuildingType();
        void _SetBuildingType(System.String val);

        System.String _GetNameOfIndoors();
        void _SetNameOfIndoors(System.String val);

        System.String _GetBaseNameOfIndoors();
        void _SetBaseNameOfIndoors(System.String val);

        System.String _GetNameOfIndoorsWithoutUnique();
        void _SetNameOfIndoorsWithoutUnique(System.String val);

        Microsoft.Xna.Framework.Point _GetHumanDoor();
        void _SetHumanDoor(Microsoft.Xna.Framework.Point val);

        Microsoft.Xna.Framework.Point _GetAnimalDoor();
        void _SetAnimalDoor(Microsoft.Xna.Framework.Point val);

        Microsoft.Xna.Framework.Color _GetColor();
        void _SetColor(Microsoft.Xna.Framework.Color val);

        bool _GetAnimalDoorOpen();
        void _SetAnimalDoorOpen(bool val);

        long _GetOwner();
        void _SetOwner(long val);

        int _GetNewConstructionTimer();
        void _SetNewConstructionTimer(int val);

        float _GetAlpha();
        void _SetAlpha(float val);

        Microsoft.Xna.Framework.Rectangle _GetLeftShadow();
        void _SetLeftShadow(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetMiddleShadow();
        void _SetMiddleShadow(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetRightShadow();
        void _SetRightShadow(Microsoft.Xna.Framework.Rectangle val);
    }
}