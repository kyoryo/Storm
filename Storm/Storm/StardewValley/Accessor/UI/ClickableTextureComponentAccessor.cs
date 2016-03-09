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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Storm.StardewValley.Accessor
{
    public interface ClickableTextureComponentAccessor : ClickableComponentAccessor
    {
        Texture2D _GetTexture();
        void _SetTexture(Texture2D val);

        Rectangle _GetSourceRect();
        void _SetSourceRect(Rectangle val);

        float _GetBaseScale();
        void _SetBaseScale(float val);

        string _GetHoverText();
        void _SetHoverText(string val);

        bool _GetDrawLabel();
        void _SetDrawLabel(bool val);

        bool _GetDrawShadow();
        void _SetDrawShadow(bool val);
    }
}