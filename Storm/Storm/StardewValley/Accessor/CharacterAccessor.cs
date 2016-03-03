using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface CharacterAccessor
    {
        bool _IsEmoteFading();

        float _GetEmoteInterval();

        Vector2 _GetLastClick();

        string _GetName();

        Vector2 _GetPosition();

        void _SetPosition(Vector2 pos);

        float _GetVelocityX();

        float _GetVelocityY();

        float _GetScale();

        int _GetSpeed();
    }
}
