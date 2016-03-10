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
    public interface TreeAccessor : TerrainFeatureAccessor
    {
        Microsoft.Xna.Framework.Graphics.Texture2D _GetTexture();
        void _SetTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        int _GetGrowthStage();
        void _SetGrowthStage(int val);

        int _GetTreeType();
        void _SetTreeType(int val);

        float _GetHealth();
        void _SetHealth(float val);

        bool _GetFlipped();
        void _SetFlipped(bool val);

        bool _GetStump();
        void _SetStump(bool val);

        bool _GetTapped();
        void _SetTapped(bool val);

        bool _GetHasSeed();
        void _SetHasSeed(bool val);

        bool _GetShakeLeft();
        void _SetShakeLeft(bool val);

        bool _GetFalling();
        void _SetFalling(bool val);

        bool _GetDestroy();
        void _SetDestroy(bool val);

        float _GetShakeRotation();
        void _SetShakeRotation(float val);

        float _GetMaxShake();
        void _SetMaxShake(float val);

        float _GetAlpha();
        void _SetAlpha(float val);

        System.Collections.IList _GetLeaves();
        void _SetLeaves(System.Collections.IList val);

        long _GetLastPlayerToHit();
        void _SetLastPlayerToHit(long val);

        float _GetShakeTimer();
        void _SetShakeTimer(float val);

        Microsoft.Xna.Framework.Rectangle _GetTreeTopSourceRect();
        void _SetTreeTopSourceRect(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetStumpSourceRect();
        void _SetStumpSourceRect(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetShadowSourceRect();
        void _SetShadowSourceRect(Microsoft.Xna.Framework.Rectangle val);
    }
}
