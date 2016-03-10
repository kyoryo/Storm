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

using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Accessor
{
    public interface HorseAccessor : NPCAccessor
    {
        FarmerAccessor _GetRider();
        void _SetRider(FarmerAccessor val);

        bool _GetMounting();
        void _SetMounting(bool val);

        bool _GetDismounting();
        void _SetDismounting(bool val);

        Microsoft.Xna.Framework.Vector2 _GetDismountTile();
        void _SetDismountTile(Microsoft.Xna.Framework.Vector2 val);

        bool _GetSqueezingThroughGate();
        void _SetSqueezingThroughGate(bool val);
    }
}