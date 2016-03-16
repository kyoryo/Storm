/*
    Copyright 2016 Inari-Whitebear

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

using Microsoft.Xna.Framework;
using Storm.StardewValley.Wrapper;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Proxy
{
    public class HUDMessageDelegate : TypeDelegate<HUDMessage>
    {
        public HUDMessageDelegate(string msg)
        {
            ConstructorParams.Add(msg);
        }

        public HUDMessageDelegate(string msg, bool achievement)
        {
            ConstructorParams.Add(msg);
            ConstructorParams.Add(achievement);
        }

        public HUDMessageDelegate(string msg, int whatType)
        {
            ConstructorParams.Add(msg);
            ConstructorParams.Add(whatType);
        }

        public HUDMessageDelegate(string type, int number, bool add, Color color, Item messageSubject = null)
        {
            ConstructorParams.Add(type);
            ConstructorParams.Add(number);
            ConstructorParams.Add(add);
            ConstructorParams.Add(color);
            ConstructorParams.Add(messageSubject?.Cast<ItemAccessor>());
        }

        public HUDMessageDelegate(string msg, Color color, float timeLeft)
        {
            ConstructorParams.Add(msg);
            ConstructorParams.Add(color);
            ConstructorParams.Add(timeLeft);
        }

        public HUDMessageDelegate(string msg, Color color, float timeLeft, bool fadeIn)
        {
            ConstructorParams.Add(msg);
            ConstructorParams.Add(color);
            ConstructorParams.Add(timeLeft);
            ConstructorParams.Add(fadeIn);
        }

        public HUDMessageDelegate(string msg, string leaveMeNull)
        {
            ConstructorParams.Add(msg);
            ConstructorParams.Add(leaveMeNull);
        }
    }
}
