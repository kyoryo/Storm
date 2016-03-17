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

using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Storm.StardewValley.Accessor
{
    public interface BuffsDisplayAccessor : ClickableMenuAccessor
    {
        BuffAccessor _GetFood();
        void _SetFood(BuffAccessor val);

        BuffAccessor _GetDrink();
        void _SetDrink(BuffAccessor val);

        IList _GetOtherBuffs();
        void _SetOtherBuffs(IList val);

        int _GetFullnessLeft();
        void _SetFullnessLeft(int val);

        int _GetQuenchedLeft();
        void _SetQuenchedLeft(int val);

        string _GetHoverText();
        void _SetHoverText(string val);
        
        bool _TryToAddFoodBuff(BuffAccessor buff, int duration);

        bool _TryToAddDrinkBuff(BuffAccessor buff);

        bool _AddOtherBuff(BuffAccessor buff);
    }
}