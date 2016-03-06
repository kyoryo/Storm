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
    }
}