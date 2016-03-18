/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class BuffsDisplay : ClickableMenu
    {
        public BuffsDisplay(StaticContext parent, BuffsDisplayAccessor accessor) :
            base(parent, accessor)
        {
        }

        public BuffsDisplay()
        {
        }

        public Buff Food
        {
            get
            {
                var tmp = Cast<BuffsDisplayAccessor>()._GetFood();
                if (tmp == null) return null;
                return new Buff(Parent, tmp);
            }
            set { Cast<BuffsDisplayAccessor>()._SetFood(value?.Cast<BuffAccessor>()); }
        }

        public Buff Drink
        {
            get
            {
                var tmp = Cast<BuffsDisplayAccessor>()._GetDrink();
                if (tmp == null) return null;
                return new Buff(Parent, tmp);
            }
            set { Cast<BuffsDisplayAccessor>()._SetDrink(value?.Cast<BuffAccessor>()); }
        }

        public WrappedProxyList<BuffAccessor, Buff> OtherBuffs
        {
            get
            {
                var tmp = Cast<BuffsDisplayAccessor>()._GetOtherBuffs();
                if (tmp == null) return null;
                return new WrappedProxyList<BuffAccessor, Buff>(tmp, i => i == null ? null : new Buff(Parent, i));
            }
        }

        public int FullnessLeft
        {
            get { return Cast<BuffsDisplayAccessor>()._GetFullnessLeft(); }
            set { Cast<BuffsDisplayAccessor>()._SetFullnessLeft(value); }
        }

        public int QuenchedLeft
        {
            get { return Cast<BuffsDisplayAccessor>()._GetQuenchedLeft(); }
            set { Cast<BuffsDisplayAccessor>()._SetQuenchedLeft(value); }
        }

        public string HoverText
        {
            get { return Cast<BuffsDisplayAccessor>()._GetHoverText(); }
            set { Cast<BuffsDisplayAccessor>()._SetHoverText(value); }
        }
        
        public bool TryToAddFoodBuff(Buff buff, int duration)
        {
            return Cast<BuffsDisplayAccessor>()._TryToAddFoodBuff(buff?.Cast<BuffAccessor>(), duration);
        }

        public bool TryToAddDrinkBuff(Buff buff)
        {
            return Cast<BuffsDisplayAccessor>()._TryToAddDrinkBuff(buff?.Cast<BuffAccessor>());
        }

        public bool AddOtherBuff(Buff buff)
        {
            return Cast<BuffsDisplayAccessor>()._AddOtherBuff(buff?.Cast<BuffAccessor>());
        }
    }
}