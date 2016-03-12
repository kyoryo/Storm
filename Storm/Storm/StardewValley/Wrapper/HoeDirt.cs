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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class HoeDirt : TerrainFeature
    {
        public HoeDirt(StaticContext parent, HoeDirtAccessor accessor) :
            base(parent, accessor)
        {
        }

        public HoeDirt()
        {
        }

        public Texture2D LightTexture
        {
            get { return Cast<HoeDirtAccessor>()._GetLightTexture(); }
            set { Cast<HoeDirtAccessor>()._SetLightTexture(value); }
        }

        public Texture2D DarkTexture
        {
            get { return Cast<HoeDirtAccessor>()._GetDarkTexture(); }
            set { Cast<HoeDirtAccessor>()._SetDarkTexture(value); }
        }

        public Texture2D SnowTexture
        {
            get { return Cast<HoeDirtAccessor>()._GetSnowTexture(); }
            set { Cast<HoeDirtAccessor>()._SetSnowTexture(value); }
        }

        public Crop Crop
        {
            get
            {
                var tmp = Cast<HoeDirtAccessor>()._GetCrop();
                if (tmp == null) return null;
                return new Crop(Parent, tmp);
            }
            set { Cast<HoeDirtAccessor>()._SetCrop(value?.Cast<CropAccessor>()); }
        }

        public int State
        {
            get { return Cast<HoeDirtAccessor>()._GetState(); }
            set { Cast<HoeDirtAccessor>()._SetState(value); }
        }

        public int Fertilizer
        {
            get { return Cast<HoeDirtAccessor>()._GetFertilizer(); }
            set { Cast<HoeDirtAccessor>()._SetFertilizer(value); }
        }

        public bool ShakeLeft
        {
            get { return Cast<HoeDirtAccessor>()._GetShakeLeft(); }
            set { Cast<HoeDirtAccessor>()._SetShakeLeft(value); }
        }

        public float ShakeRotation
        {
            get { return Cast<HoeDirtAccessor>()._GetShakeRotation(); }
            set { Cast<HoeDirtAccessor>()._SetShakeRotation(value); }
        }

        public float MaxShake
        {
            get { return Cast<HoeDirtAccessor>()._GetMaxShake(); }
            set { Cast<HoeDirtAccessor>()._SetMaxShake(value); }
        }

        public float ShakeRate
        {
            get { return Cast<HoeDirtAccessor>()._GetShakeRate(); }
            set { Cast<HoeDirtAccessor>()._SetShakeRate(value); }
        }

        public Color C
        {
            get { return Cast<HoeDirtAccessor>()._GetC(); }
            set { Cast<HoeDirtAccessor>()._SetC(value); }
        }

        public bool IsReadyForHarvest
        {
            get { return Cast<HoeDirtAccessor>()._IsReadyForHarvest(); }
        }
    }
}