using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Fence : Object, Wrapper<FenceAccessor>
    {
        private readonly FenceAccessor accessor;

        public Fence(StaticContext parent, FenceAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public int FencePieceWidth
        {
            get { return accessor._GetFencePieceWidth(); }
            set { accessor._SetFencePieceWidth(value); }
        }

        public int FencePieceHeight
        {
            get { return accessor._GetFencePieceHeight(); }
            set { accessor._SetFencePieceHeight(value); }
        }

        public Texture2D FenceTexture
        {
            get { return accessor._GetFenceTexture(); }
            set { accessor._SetFenceTexture(value); }
        }

        public float Health
        {
            get { return accessor._GetHealth(); }
            set { accessor._SetHealth(value); }
        }

        public float MaxHealth
        {
            get { return accessor._GetMaxHealth(); }
            set { accessor._SetMaxHealth(value); }
        }

        public int WhichType
        {
            get { return accessor._GetWhichType(); }
            set { accessor._SetWhichType(value); }
        }

        public int GatePosition
        {
            get { return accessor._GetGatePosition(); }
            set { accessor._SetGatePosition(value); }
        }

        public int GateMotion
        {
            get { return accessor._GetGateMotion(); }
            set { accessor._SetGateMotion(value); }
        }

        public IDictionary FenceDrawGuide
        {
            get { return accessor._GetFenceDrawGuide(); }
            set { accessor._SetFenceDrawGuide(value); }
        }

        public bool IsGate
        {
            get { return accessor._GetIsGate(); }
            set { accessor._SetIsGate(value); }
        }

        public new FenceAccessor Expose() => accessor;
    }
}