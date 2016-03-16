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

using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Storm.StardewValley.Accessor
{
    public interface HUDMessageAccessor
    {
        string _GetMessage();
        void _SetMessage(string val);

        string _GetType();
        void _SetType(string val);

        Color _GetColor();
        void _SetColor(Color val);

        float _GetTimeLeft();
        void _SetTimeLeft(float val);

        float _GetTransparency();
        void _SetTransparency(float val);

        int _GetNumber();
        void _SetNumber(int val);

        int _GetWhatType();
        void _SetWhatType(int val);

        bool _GetAdd();
        void _SetAdd(bool val);

        bool _GetAchievement();
        void _SetAchievement(bool val);

        bool _GetFadeIn();
        void _SetFadeIn(bool val);

        bool _GetNoIcon();
        void _SetNoIcon(bool val);
    }
}