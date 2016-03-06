/*
    Copyright 2016 Zoey (Zoryn)

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

namespace Storm.StardewValley.Event
{
    public class FarmerDamageEvent : StaticContextEvent
    {
        public FarmerDamageEvent(int damage, bool overrideParry, Monster damager)
        {
            Damage = damage;
            OverrideParry = overrideParry;
            Damager = damager;
        }

        public int Damage { get; }
        public bool OverrideParry { get; }
        public Monster Damager { get; }
    }
}