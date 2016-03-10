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
    public interface ScreenSwipeAccessor
    {
        Microsoft.Xna.Framework.Rectangle _GetBgSource();
        void _SetBgSource(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetFlairSource();
        void _SetFlairSource(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetMessageSource();
        void _SetMessageSource(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetMovingFlairSource();
        void _SetMovingFlairSource(Microsoft.Xna.Framework.Rectangle val);

        Microsoft.Xna.Framework.Rectangle _GetBgDest();
        void _SetBgDest(Microsoft.Xna.Framework.Rectangle val);

        int _GetYPosition();
        void _SetYPosition(int val);

        int _GetDurationAfterSwipe();
        void _SetDurationAfterSwipe(int val);

        int _GetOriginalBGSourceXLimit();
        void _SetOriginalBGSourceXLimit(int val);

        System.Collections.IList _GetFlairPositions();
        void _SetFlairPositions(System.Collections.IList val);

        Microsoft.Xna.Framework.Vector2 _GetMessagePosition();
        void _SetMessagePosition(Microsoft.Xna.Framework.Vector2 val);

        Microsoft.Xna.Framework.Vector2 _GetMovingFlairPosition();
        void _SetMovingFlairPosition(Microsoft.Xna.Framework.Vector2 val);

        Microsoft.Xna.Framework.Vector2 _GetMovingFlairMotion();
        void _SetMovingFlairMotion(Microsoft.Xna.Framework.Vector2 val);

        float _GetSwipeVelocity();
        void _SetSwipeVelocity(float val);
    }
}
