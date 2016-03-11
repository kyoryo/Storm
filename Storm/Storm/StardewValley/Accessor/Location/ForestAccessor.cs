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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface ForestAccessor
    {
        System.Collections.IList _GetMarniesLivestock();
        void _SetMarniesLivestock(System.Collections.IList val);

        System.Collections.IList _GetTravelingMerchantBounds();
        void _SetTravelingMerchantBounds(System.Collections.IList val);

        System.Collections.IDictionary _GetTravelingMerchantStock();
        void _SetTravelingMerchantStock(System.Collections.IDictionary val);

        bool _GetTravelingMerchantDay();
        void _SetTravelingMerchantDay(bool val);

        ResourceClumpAccessor _GetLog();
        void _SetLog(ResourceClumpAccessor val);

        int _GetChimneyTimer();
        void _SetChimneyTimer(int val);

        Microsoft.Xna.Framework.Rectangle _GetHatterSource();
        void _SetHatterSource(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Vector2 _GetHatterPos();
        void _SetHatterPos(Microsoft.Xna.Framework.Vector2 val);
    }
}
