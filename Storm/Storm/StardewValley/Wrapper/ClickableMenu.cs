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
    public class ClickableMenu : Wrapper<ClickableMenuAccessor>
    {
        private readonly ClickableMenuAccessor accessor;

        public ClickableMenu(StaticContext parent, ClickableMenuAccessor accessor)
        {
            Parent = parent;
            this.accessor = accessor;
        }

        public StaticContext Parent { get; }

        public ClickableMenuAccessor Expose() => accessor;

        public bool IsShopMenu() => accessor is ShopMenuAccessor;

        public ShopMenu ToShopMenu() => new ShopMenu(Parent, accessor as ShopMenuAccessor);

        public bool IsBillboard() => accessor is BillboardAccessor;

        public Billboard ToBillboard() => new Billboard(Parent, accessor as BillboardAccessor);
    }
}