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

using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Billboard : ClickableMenu, Wrapper<BillboardAccessor>
    {
        private readonly BillboardAccessor accessor;

        public Billboard(StaticContext parent, BillboardAccessor accessor) :
            base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public Texture2D BillboardTexture
        {
            get { return accessor._GetBillboardTexture(); }
            set { accessor._SetBillboardTexture(value); }
        }

        public bool DailyQuestBoard
        {
            get { return accessor._GetDailyQuestBoard(); }
            set { accessor._SetDailyQuestBoard(value); }
        }

        public ClickableComponent AcceptQuestButton
        {
            get { return new ClickableComponent(Parent, accessor._GetAcceptQuestButton()); }
            set { accessor._SetAcceptQuestButton(value.Expose()); }
        }

        public ProxyList<ClickableTextureComponentAccessor, ClickableTextureComponent> CalendarDays
        {
            get
            {
                return new ProxyList<ClickableTextureComponentAccessor, ClickableTextureComponent>(
                    accessor._GetCalendarDays(), i => new ClickableTextureComponent(Parent, i));
            }
        }

        public string HoverText
        {
            get { return accessor._GetHoverText(); }
            set { accessor._SetHoverText(value); }
        }

        public new BillboardAccessor Expose() => accessor;
    }
}