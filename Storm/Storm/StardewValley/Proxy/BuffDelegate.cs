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
    public class BuffDelegate : TypeDelegate<Buff>
    {
        public BuffDelegate(string description, int millisecondsDuration, string source, int index)
        {
            ConstructorParams.Add(description);
            ConstructorParams.Add(millisecondsDuration);
            ConstructorParams.Add(source);
            ConstructorParams.Add(index);
        }

        public BuffDelegate(int which)
        {
            ConstructorParams.Add(which);
        }

        public BuffDelegate(int farming, int fishing, int mining, int digging, int luck, int foraging, int crafting, int maxStamina, int magneticRadius, int speed, int defense, int attack, int minutesDuration, string source)
        {
            ConstructorParams.Add(farming);
            ConstructorParams.Add(fishing);
            ConstructorParams.Add(mining);
            ConstructorParams.Add(digging);
            ConstructorParams.Add(luck);
            ConstructorParams.Add(foraging);
            ConstructorParams.Add(crafting);
            ConstructorParams.Add(maxStamina);
            ConstructorParams.Add(magneticRadius);
            ConstructorParams.Add(speed);
            ConstructorParams.Add(defense);
            ConstructorParams.Add(attack);
            ConstructorParams.Add(minutesDuration);
            ConstructorParams.Add(source);
        }

    }
}
