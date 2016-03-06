using System.Collections;
using Microsoft.Xna.Framework.Graphics;

namespace Storm.StardewValley.Accessor
{
    public interface FenceAccessor : ObjectAccessor
    {
        int _GetFencePieceWidth();
        void _SetFencePieceWidth(int val);

        int _GetFencePieceHeight();
        void _SetFencePieceHeight(int val);

        Texture2D _GetFenceTexture();
        void _SetFenceTexture(Texture2D val);

        float _GetHealth();
        void _SetHealth(float val);

        float _GetMaxHealth();
        void _SetMaxHealth(float val);

        int _GetWhichType();
        void _SetWhichType(int val);

        int _GetGatePosition();
        void _SetGatePosition(int val);

        int _GetGateMotion();
        void _SetGateMotion(int val);

        IDictionary _GetFenceDrawGuide();
        void _SetFenceDrawGuide(IDictionary val);

        bool _GetIsGate();
        void _SetIsGate(bool val);
    }
}