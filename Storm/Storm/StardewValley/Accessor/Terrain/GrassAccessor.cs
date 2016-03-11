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

namespace Storm.StardewValley.Accessor.Terrain
{
    public interface GrassAccessor : TerrainFeatureAccessor
    {
        Microsoft.Xna.Framework.Audio.Cue _GetGrassSound();
        void _SetGrassSound(Microsoft.Xna.Framework.Audio.Cue val);

        Microsoft.Xna.Framework.Graphics.Texture2D _GetTexture();
        void _SetTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        byte _GetGrassType();
        void _SetGrassType(byte val);

        bool _GetShakeLeft();
        void _SetShakeLeft(bool val);

        float _GetShakeRotation();
        void _SetShakeRotation(float val);

        float _GetMaxShake();
        void _SetMaxShake(float val);

        float _GetShakeRate();
        void _SetShakeRate(float val);

        int _GetNumberOfWeeds();
        void _SetNumberOfWeeds(int val);

        int _GetGrassSourceOffset();
        void _SetGrassSourceOffset(int val);

        int _GetWhichWeed();
        void _SetWhichWeed(int val);

        int _GetOffset1();
        void _SetOffset1(int val);

        int _GetOffset2();
        void _SetOffset2(int val);

        int _GetOffset3();
        void _SetOffset3(int val);

        int _GetOffset4();
        void _SetOffset4(int val);

        bool _GetFlip();
        void _SetFlip(bool val);

        double _GetShakeRandom();
        void _SetShakeRandom(double val);
    }
}
