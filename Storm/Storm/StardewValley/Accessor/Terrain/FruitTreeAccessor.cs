using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface FruitTreeAccessor : TerrainFeatureAccessor
    {
        Microsoft.Xna.Framework.Graphics.Texture2D _GetTexture();
        void _SetTexture(Microsoft.Xna.Framework.Graphics.Texture2D val);

        int _GetGrowthStage();
        void _SetGrowthStage(int val);

        int _GetTreeType();
        void _SetTreeType(int val);

        int _GetIndexOfFruit();
        void _SetIndexOfFruit(int val);

        int _GetDaysUntilMature();
        void _SetDaysUntilMature(int val);

        int _GetFruitsOnTree();
        void _SetFruitsOnTree(int val);

        float _GetHealth();
        void _SetHealth(float val);

        bool _GetFlipped();
        void _SetFlipped(bool val);

        bool _GetStump();
        void _SetStump(bool val);

        bool _GetGreenHouseTree();
        void _SetGreenHouseTree(bool val);

        bool _GetShakeLeft();
        void _SetShakeLeft(bool val);

        bool _GetFalling();
        void _SetFalling(bool val);

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

        System.String _GetFruitSeason();
        void _SetFruitSeason(System.String val);

        float _GetShakeTimer();
        void _SetShakeTimer(float val);
    }
}
