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

using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class GameMenu : ClickableMenu, Wrapper<GameMenuAccessor>
    {
        private readonly GameMenuAccessor accessor;

        public GameMenu(StaticContext parent, GameMenuAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public int CurrentTab
        {
            get { return accessor._GetCurrentTab(); }
            set { accessor._SetCurrentTab(value); }
        }

        public string HoverText
        {
            get { return accessor._GetHoverText(); }
            set { accessor._SetHoverText(value); }
        }

        public string DescriptionText
        {
            get { return accessor._GetDescriptionText(); }
            set { accessor._SetDescriptionText(value); }
        }

        public bool Invisible
        {
            get { return accessor._GetInvisible(); }
            set { accessor._SetInvisible(value); }
        }

        public bool ForcePreventClose
        {
            get { return accessor._GetForcePreventClose(); }
            set { accessor._SetForcePreventClose(value); }
        }

        public new GameMenuAccessor Expose() => accessor;
    }
}