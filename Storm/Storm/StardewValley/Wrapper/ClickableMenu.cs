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
    public class ClickableMenu : Wrapper
    {
        private readonly ClickableMenuAccessor accessor;

        public ClickableMenu(StaticContext parent, ClickableMenuAccessor accessor)
        {
            Parent = parent;
            this.accessor = accessor;
        }

        public StaticContext Parent { get; }

        public object Expose() => accessor;

        public bool IsChatBox() => accessor is ChatBoxAccessor;
        public ChatBox ToChatBox() => new ChatBox(Parent, accessor as ChatBoxAccessor);

        public bool IsGameMenu() => accessor is GameMenuAccessor;
        public GameMenu ToGameMenu() => new GameMenu(Parent, accessor as GameMenuAccessor);

        public bool IsShopMenu() => accessor is ShopMenuAccessor;
        public ShopMenu ToShopMenu() => new ShopMenu(Parent, accessor as ShopMenuAccessor);

        public bool IsInventoryMenu() => accessor is InventoryMenuAccessor;
        public InventoryMenu ToInventoryMenu() => new InventoryMenu(Parent, accessor as InventoryMenuAccessor);

        public bool IsInventoryPage() => accessor is InventoryPageAccessor;
        public InventoryPage ToInventoryPage() => new InventoryPage(Parent, accessor as InventoryPageAccessor);

        public bool IsBillboard() => accessor is BillboardAccessor;
        public Billboard ToBillboard() => new Billboard(Parent, accessor as BillboardAccessor);

        public bool IsBobberBar() => accessor is BobberBarAccessor;
        public BobberBar ToBobberBar() => new BobberBar(Parent, accessor as BobberBarAccessor);
    }
}