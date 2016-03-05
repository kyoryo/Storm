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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event
{
    public class PlayerDamagedEvent : StaticContextEvent
    {
        private int damage;
        private bool overrideParry;
        private MonsterAccessor damager;

        public PlayerDamagedEvent(int damage, bool overrideParry, MonsterAccessor damager)
        {
            this.damage = damage;
            this.overrideParry = overrideParry;
            this.damager = damager;
        }

        public int Damage { get { return damage; } }
        public bool OverrideParry { get { return overrideParry; } }
        public MonsterAccessor Damager { get { return damager; } }
    }
}
