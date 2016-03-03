using Storm.StardewValley.Accessor;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Character
    {
        private CharacterAccessor accessor;

        public Character(CharacterAccessor accessor)
        {
            this.accessor = accessor;
        }

        public bool IsEmoteFading()
        {
            return accessor._IsEmoteFading();
        }

        public float GetEmoteInterval()
        {
            return accessor._GetEmoteInterval();
        }

        public Vector2 GetLastClick()
        {
            return accessor._GetLastClick();
        }

        public string GetName()
        {
            return accessor._GetName();
        }

        public Vector2 GetPosition()
        {
            return accessor._GetPosition();
        }

        public void SetPosition(Vector2 pos)
        {
            accessor._SetPosition(pos);
        }

        public float GetVelocityX()
        {
            return accessor._GetVelocityX();
        }

        public float GetVelocityY()
        {
            return accessor._GetVelocityY();
        }

        public float GetScale()
        {
            return accessor._GetScale();
        }

        public int GetSpeed()
        {
            return accessor._GetSpeed();
        }

    }
}
