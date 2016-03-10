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

using System;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Tool : Item
    {
        private readonly ToolAccessor accessor;

        public Tool(StaticContext parent, ToolAccessor accessor) : base(parent, accessor)
        {
            this.accessor = accessor;
        }

        public ObjectItem[] Attachments
        {
            get { return Array.ConvertAll(accessor._GetAttachments(), i => new ObjectItem(Parent, i)); }
            set { accessor._SetAttachments(Array.ConvertAll(value, i => i.Cast<ObjectAccessor>())); }
        }
        /// <summary>
        /// The name of this tool
        /// </summary>
        /// <value>The Name property gets/sets the value of the string field Name</value>
        public string Name
        {
            get { return accessor._GetName(); }
            set { accessor._SetName(value); }
        }
        /// <summary>
        /// The description of this tool
        /// </summary>
        /// <value>The Description propertly gets/sets the value of the string field Description</value>
        public string Description
        {
            get { return accessor._GetDescription(); }
            set { accessor._SetDescription(value); }
        }

        public bool IsStackable
        {
            get { return accessor._GetIsStackable(); }
            set { accessor._SetIsStackable(value); }
        }
        /// <summary>
        /// The upgrade level of this tool
        /// Default = 0
        /// Copper = 1
        /// Iron = 2
        /// Gold = 3
        /// Iridium = 4
        /// </summary>
        /// <value>The UpgradeLevel property sets/gets the value of the int field UpgradeLevel</value>
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

        /// <summary>
        /// Whether this tool is fishing rod or not
        /// </summary>
        /// <returns>A boolean representing the fishing rod status of this tool</returns>
        public bool IsFishingRod() => accessor is FishingRodAccessor;

        /// <summary>
        /// Turns this tool into a fishing rod
        /// </summary>
        /// <returns>A new Fishing Rod</returns>
        public FishingRod ToFishingRod() => new FishingRod(Parent, (FishingRodAccessor) accessor);
    }
}