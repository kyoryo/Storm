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

using Microsoft.Xna.Framework.Graphics;
using Storm.Collections;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Billboard : ClickableMenu
    {
        public Billboard(StaticContext parent, BillboardAccessor accessor) :
            base(parent, accessor)
        {
        }

        public Billboard()
        {
        }

        public Texture2D BillboardTexture
        {
            get { return Cast<BillboardAccessor>()._GetBillboardTexture(); }
            set { Cast<BillboardAccessor>()._SetBillboardTexture(value); }
        }

        public bool DailyQuestBoard
        {
            get { return Cast<BillboardAccessor>()._GetDailyQuestBoard(); }
            set { Cast<BillboardAccessor>()._SetDailyQuestBoard(value); }
        }

        public ClickableComponent AcceptQuestButton
        {
            get
            {
                var tmp = Cast<BillboardAccessor>()._GetAcceptQuestButton();
                if (tmp == null) return null;
                return new ClickableComponent(Parent, tmp);
            }
            set { Cast<BillboardAccessor>()._SetAcceptQuestButton(value.Cast<ClickableComponentAccessor>()); }
        }

        public WrappedProxyList<ClickableTextureComponentAccessor, ClickableTextureComponent> CalendarDays
        {
            get
            {
                var tmp = Cast<BillboardAccessor>()._GetCalendarDays();
                if (tmp == null) return null;
                return new WrappedProxyList<ClickableTextureComponentAccessor, ClickableTextureComponent>(tmp,
                    i => new ClickableTextureComponent(Parent, i));
            }
        }

        public string HoverText
        {
            get { return Cast<BillboardAccessor>()._GetHoverText(); }
            set { Cast<BillboardAccessor>()._SetHoverText(value); }
        }
    }
}