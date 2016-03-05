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
using Storm.StardewValley.Accessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Farmer : Character, Wrapper<FarmerAccessor>
    {
        private FarmerAccessor accessor;

        public Farmer(StaticContext parent, FarmerAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public List<Item> Items
        {
            get
            {
                return accessor.
                    _GetItems().
                    Cast<ItemAccessor>().
                    Where(i => i != null).
                    Select(i => new Item(Parent, i)).
                    ToList();
            }
        }

        public void SetItem(int idx, Item item)
        {
            accessor._GetItems()[idx] = item.Expose();
        }

        public string FarmName
        {
            get { return accessor._GetFarmName(); }
            set { accessor._SetFarmName(value); }
        }

        public string Name
        {
            get { return accessor._GetName(); }
            set { accessor._SetName(value); }
        }

        public int Money
        {
            get { return accessor._GetMoney(); }
            set { accessor._SetMoney(value); }
        }

        public int Health
        {
            get { return accessor._GetHealth(); }
            set { accessor._SetHealth(value); }
        }

        public int MaxHealth
        {
            get { return accessor._GetMaxHealth(); }
            set { accessor._SetMaxHealth(value); }
        }

        public float Stamina
        {
            get { return accessor._GetStamina(); }
            set { accessor._SetStamina(value); }
        }

        public int MaxStamina
        {
            get { return accessor._GetMaxStamina(); }
            set { accessor._SetMaxStamina(value); }
        }

        public uint MillisecondsPlayed
        {
            get { return accessor._GetMillisecondsPlayed(); }
            set { accessor._SetMillisecondsPlayed(value); }
        }

        public int HouseUpgradeLevel
        {
            get { return accessor._GetHouseUpgradeLevel(); }
            set { accessor._SetHouseUpgradeLevel(value); }
        }

        public new FarmerAccessor Expose() => accessor;
    }
}
