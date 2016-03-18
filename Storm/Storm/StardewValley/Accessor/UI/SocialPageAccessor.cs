/*
    Copyright 2016 Dmitry Akulinin (Sharkman)

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

namespace Storm.StardewValley.Accessor
{
    public interface SocialPageAccessor : ClickableMenuAccessor
    {
        string _GetDescriptionText();
        void _SetDescriptionText(string val);

        string _GetHoverText();
        void _SetHoverText(string val);

        IList _GetFriendNames();
        void _SetFriendNames(IList val);

        int _GetSlotPosition();
        void _SetSlotPosition(int val);

        IList _GetKidsNames();
        void _SetKidsNames(IList val);
    }
}
