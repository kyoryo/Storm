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
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class HoeDirt : TerrainFeature, Wrapper<HoeDirtAccessor>
    {
        private readonly HoeDirtAccessor accessor;

        public HoeDirt(StaticContext parent, HoeDirtAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public Texture2D LightTexture
        {
            get { return accessor._GetLightTexture(); }
            set { accessor._SetLightTexture(value); }
        }

        public Texture2D DarkTexture
        {
            get { return accessor._GetDarkTexture(); }
            set { accessor._SetDarkTexture(value); }
        }

        public Texture2D SnowTexture
        {
            get { return accessor._GetSnowTexture(); }
            set { accessor._SetSnowTexture(value); }
        }

        public CropAccessor Crop
        {
            get { return accessor._GetCrop(); }
            set { accessor._SetCrop(value); }
        }

        public IDictionary DrawGuide
        {
            get { return accessor._GetDrawGuide(); }
            set { accessor._SetDrawGuide(value); }
        }

        public int State
        {
            get { return accessor._GetState(); }
            set { accessor._SetState(value); }
        }

        public int Fertilizer
        {
            get { return accessor._GetFertilizer(); }
            set { accessor._SetFertilizer(value); }
        }

        public bool ShakeLeft
        {
            get { return accessor._GetShakeLeft(); }
            set { accessor._SetShakeLeft(value); }
        }

        public float ShakeRotation
        {
            get { return accessor._GetShakeRotation(); }
            set { accessor._SetShakeRotation(value); }
        }

        public float MaxShake
        {
            get { return accessor._GetMaxShake(); }
            set { accessor._SetMaxShake(value); }
        }

        public float ShakeRate
        {
            get { return accessor._GetShakeRate(); }
            set { accessor._SetShakeRate(value); }
        }

        public Color C
        {
            get { return accessor._GetC(); }
            set { accessor._SetC(value); }
        }

        public new HoeDirtAccessor Expose() => accessor;
    }
}