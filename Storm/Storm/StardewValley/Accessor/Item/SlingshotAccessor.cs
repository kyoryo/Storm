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
    public interface SlingshotAccessor : ToolAccessor
    {
        int _GetRecentClickX();
        void _SetRecentClickX(int val);

        int _GetRecentClickY();
        void _SetRecentClickY(int val);

        int _GetLastClickX();
        void _SetLastClickX(int val);

        int _GetLastClickY();
        void _SetLastClickY(int val);

        int _GetMouseDragAmount();
        void _SetMouseDragAmount(int val);

        bool _GetCanPlaySound();
        void _SetCanPlaySound(bool val);

        bool _GetStartedWithGamePad();
        void _SetStartedWithGamePad(bool val);
    }
}
