/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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

using Storm.Collections;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class GameMenu : ClickableMenu
    {
        public GameMenu(StaticContext parent, GameMenuAccessor accessor) :
            base(parent, accessor)
        {
        }

        public GameMenu()
        {
        }

        public int CurrentTab
        {
            get { return Cast<GameMenuAccessor>()._GetCurrentTab(); }
            set { Cast<GameMenuAccessor>()._SetCurrentTab(value); }
        }

        public string HoverText
        {
            get { return Cast<GameMenuAccessor>()._GetHoverText(); }
            set { Cast<GameMenuAccessor>()._SetHoverText(value); }
        }

        public string DescriptionText
        {
            get { return Cast<GameMenuAccessor>()._GetDescriptionText(); }
            set { Cast<GameMenuAccessor>()._SetDescriptionText(value); }
        }

        public bool Invisible
        {
            get { return Cast<GameMenuAccessor>()._GetInvisible(); }
            set { Cast<GameMenuAccessor>()._SetInvisible(value); }
        }

        public bool ForcePreventClose
        {
            get { return Cast<GameMenuAccessor>()._GetForcePreventClose(); }
            set { Cast<GameMenuAccessor>()._SetForcePreventClose(value); }
        }

        public WrappedProxyList<ClickableMenuAccessor, ClickableMenu> Pages
        {
            get
            {
                var tmp = Cast<GameMenuAccessor>()._GetPages();
                if (tmp == null) return null;
                return new WrappedProxyList<ClickableMenuAccessor, ClickableMenu>(tmp, i => i == null ? null : new ClickableMenu(Parent, i));
            }
        }
    }
}