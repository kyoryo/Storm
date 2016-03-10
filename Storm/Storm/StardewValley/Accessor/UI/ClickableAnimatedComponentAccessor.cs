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
    public interface ClickableAnimatedComponentAccessor : ClickableComponentAccessor
    {
        TempAnimatedSpriteAccessor _GetSprite();
        void _SetSprite(TempAnimatedSpriteAccessor val);

        Microsoft.Xna.Framework.Rectangle _GetSourceRect();
        void _SetSourceRect(Microsoft.Xna.Framework.Rectangle val);

        float _GetBaseScale();
        void _SetBaseScale(float val);

        System.String _GetHoverText();
        void _SetHoverText(System.String val);

        bool _GetDrawLabel();
        void _SetDrawLabel(bool val);
    }
}
