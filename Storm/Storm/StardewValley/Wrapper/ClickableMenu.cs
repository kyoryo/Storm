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

using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class ClickableMenu : StaticContextWrapper
    {
        public ClickableMenu(StaticContext parent, ClickableMenuAccessor accessor) : 
            base(parent)
        {
            Accessor = accessor;
        }

        public ClickableMenu()
        {
        }

        public override object Expose() => Accessor;

        public bool IsChatBox() => Cast<ClickableMenuAccessor>() is ChatBoxAccessor;
        public ChatBox ToChatBox() => new ChatBox(Parent, Cast<ClickableMenuAccessor>() as ChatBoxAccessor);

        public bool IsGameMenu() => Cast<ClickableMenuAccessor>() is GameMenuAccessor;
        public GameMenu ToGameMenu() => new GameMenu(Parent, Cast<ClickableMenuAccessor>() as GameMenuAccessor);

        public bool IsShopMenu() => Cast<ClickableMenuAccessor>() is ShopMenuAccessor;
        public ShopMenu ToShopMenu() => new ShopMenu(Parent, Cast<ClickableMenuAccessor>() as ShopMenuAccessor);

        public bool IsInventoryMenu() => Cast<ClickableMenuAccessor>() is InventoryMenuAccessor;
        public InventoryMenu ToInventoryMenu() => new InventoryMenu(Parent, Cast<ClickableMenuAccessor>() as InventoryMenuAccessor);

        public bool IsInventoryPage() => Cast<ClickableMenuAccessor>() is InventoryPageAccessor;
        public InventoryPage ToInventoryPage() => new InventoryPage(Parent, Cast<ClickableMenuAccessor>() as InventoryPageAccessor);

        public bool IsBillboard() => Cast<ClickableMenuAccessor>() is BillboardAccessor;
        public Billboard ToBillboard() => new Billboard(Parent, Cast<ClickableMenuAccessor>() as BillboardAccessor);

        public bool IsBobberBar() => Cast<ClickableMenuAccessor>() is BobberBarAccessor;
        public BobberBar ToBobberBar() => new BobberBar(Parent, Cast<ClickableMenuAccessor>() as BobberBarAccessor);
    }
}