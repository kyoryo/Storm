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
using Microsoft.Xna.Framework;

namespace Storm.StardewValley.Proxy
{
    public class ObjectDelegate : TypeDelegate<ObjectItem>
    {
        public ObjectDelegate()
        {
        }

        public ObjectDelegate(Vector2 tileLocation, int parentSheetIndex, string name, bool canBeSetDown, bool canBeGrabbed, bool isHoedirt, bool isSpawnedObject)
        {
            ConstructorParams.Add(tileLocation);
            ConstructorParams.Add(parentSheetIndex);
            ConstructorParams.Add(name);
            ConstructorParams.Add(canBeSetDown);
            ConstructorParams.Add(canBeGrabbed);
            ConstructorParams.Add(isHoedirt);
            ConstructorParams.Add(isSpawnedObject);
        }

        public virtual OverrideEvent DrawInMenu(object[] @params)
        {
            return new OverrideEvent
            {
                ReturnEarly = false
            };
        }
    }
}