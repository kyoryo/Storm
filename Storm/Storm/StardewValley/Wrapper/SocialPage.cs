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

using Storm.Collections;
using Storm.StardewValley.Accessor;
using System.Collections;
using System.Collections.Generic;

namespace Storm.StardewValley.Wrapper
{
    public class SocialPage : ClickableMenu
    {
        public string DescriptionText
        {
            get { return Cast<SocialPageAccessor>()._GetDescriptionText(); }
            set { Cast<SocialPageAccessor>()._SetDescriptionText(value); }
        }

        public string HoverText
        {
            get { return Cast<SocialPageAccessor>()._GetHoverText(); }
            set { Cast<SocialPageAccessor>()._SetHoverText(value); }
        }

        public WrappedProxyList<ClickableTextureComponentAccessor, ClickableTextureComponent> FriendNames
        {
            get
            {
                IList list = base.Cast<SocialPageAccessor>()._GetFriendNames();
                if (list == null)
                {
                    return null;
                }

                return new WrappedProxyList<ClickableTextureComponentAccessor, ClickableTextureComponent>(list, delegate (ClickableTextureComponentAccessor i)
                {
                    if (i != null)
                    {
                        return new ClickableTextureComponent(base.Parent, i);
                    }
                    return null;
                });
            }
        }

        public int SlotPosition
        {
            get { return Cast<SocialPageAccessor>()._GetSlotPosition(); }
            set { Cast<SocialPageAccessor>()._SetSlotPosition(value); }
        }

        public ProxyList<string> KidsNames
        {
            get {
                IList list = base.Cast<SocialPageAccessor>()._GetKidsNames();
                if (list == null)
                {
                    return null;
                }

                return new ProxyList<string>(list);
            }
        }

        public SocialPage(StaticContext parent, SocialPageAccessor accessor) : base(parent, accessor)
        {
        }

        public SocialPage()
        {
        }
    }
}
