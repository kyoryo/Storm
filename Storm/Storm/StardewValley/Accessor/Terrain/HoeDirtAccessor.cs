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
    public interface HoeDirtAccessor : TerrainFeatureAccessor
    {
        Texture2D _GetLightTexture();
        void _SetLightTexture(Texture2D val);

        Texture2D _GetDarkTexture();
        void _SetDarkTexture(Texture2D val);

        Texture2D _GetSnowTexture();
        void _SetSnowTexture(Texture2D val);

        CropAccessor _GetCrop();
        void _SetCrop(CropAccessor val);

        IDictionary _GetDrawGuide();
        void _SetDrawGuide(IDictionary val);

        int _GetState();
        void _SetState(int val);

        int _GetFertilizer();
        void _SetFertilizer(int val);

        bool _GetShakeLeft();
        void _SetShakeLeft(bool val);

        float _GetShakeRotation();
        void _SetShakeRotation(float val);

        float _GetMaxShake();
        void _SetMaxShake(float val);

        float _GetShakeRate();
        void _SetShakeRate(float val);

        Color _GetC();
        void _SetC(Color val);

        bool _IsReadyForHarvest();
    }
}