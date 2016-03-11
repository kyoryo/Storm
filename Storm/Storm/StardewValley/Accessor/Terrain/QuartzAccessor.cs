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
    public interface QuartzAccessor : TerrainFeatureAccessor
    {
        Microsoft.Xna.Framework.Graphics.Texture2D _GetTexture();
        void _SetTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        float _GetHealth();
        void _SetHealth(float val);

        bool _GetFlipped();
        void _SetFlipped(bool val);

        bool _GetShakeLeft();
        void _SetShakeLeft(bool val);

        bool _GetFalling();
        void _SetFalling(bool val);

        float _GetShakeRotation();
        void _SetShakeRotation(float val);

        float _GetMaxShake();
        void _SetMaxShake(float val);

        float _GetGlow();
        void _SetGlow(float val);

        int _GetBigness();
        void _SetBigness(int val);

        int _GetIdentifier();
        void _SetIdentifier(int val);

        Microsoft.Xna.Framework.Color _GetColor();
        void _SetColor(Microsoft.Xna.Framework.Color val);
    }
}
