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
    public interface BundleAccessor : ClickableComponentAccessor
    {
        System.String _GetRewardDescription();
        void _SetRewardDescription(System.String val);

        System.Collections.IList _GetIngredients();
        void _SetIngredients(System.Collections.IList val);

        int _GetBundleColor();
        void _SetBundleColor(int val);

        int _GetNumberOfIngredientSlots();
        void _SetNumberOfIngredientSlots(int val);

        int _GetBundleIndex();
        void _SetBundleIndex(int val);

        int _GetCompletionTimer();
        void _SetCompletionTimer(int val);

        bool _GetComplete();
        void _SetComplete(bool val);

        bool _GetDepositsAllowed();
        void _SetDepositsAllowed(bool val);

        TempAnimatedSpriteAccessor _GetSprite();
        void _SetSprite(TempAnimatedSpriteAccessor val);

        float _GetMaxShake();
        void _SetMaxShake(float val);

        bool _GetShakeLeft();
        void _SetShakeLeft(bool val);
    }
}
