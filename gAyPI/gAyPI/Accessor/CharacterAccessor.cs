using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.Accessor
{
    public interface CharacterAccessor
    {
        bool IsEmoteFading();

        float GetEmoteInterval();

        Vector2 GetLastClick();

        string GetName();

        Vector2 GetPosition();

        float GetVelocityX();

        float GetVelocityY();

        float GetScale();

        int GetSpeed();
    }
}
