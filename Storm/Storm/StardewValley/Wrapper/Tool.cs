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
using System;

namespace Storm.StardewValley.Wrapper
{
    public class Tool : Item, Wrapper<ToolAccessor>
    {
        private ToolAccessor accessor;

        public Tool(StaticContext parent, ToolAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public Object[] Attachments
        {
            get
            {
                return Array.ConvertAll(accessor._GetAttachments(), (i) => new Object(Parent, i));
            }
            set
            {
                accessor._SetAttachments(Array.ConvertAll(value, (i) => i.Expose()));
            }
        }

        public string Name
        {
            get { return accessor._GetName(); }
            set { accessor._SetName(value); }
        }

        public string Description
        {
            get { return accessor._GetDescription(); }
            set { accessor._SetDescription(value); }
        }

        public bool Stackable
        {
            get { return accessor._GetIsStackable(); }
            set { accessor._SetIsStackable(value); }
        }

        public int UpgradeLevel
        {
            get { return accessor._GetUpgradeLevel(); }
            set { accessor._SetUpgradeLevel(value); }
        }

        public Texture2D WeaponTexture
        {
            get { return accessor._GetWeaponTexture(); }
            set { accessor._SetWeaponTexture(value); }
        }

        public new ToolAccessor Expose() => accessor;
    }
}
