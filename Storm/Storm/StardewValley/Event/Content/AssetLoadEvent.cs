/*
    Copyright 2016 Matthew Bell

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

using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class AssetLoadEvent : StaticContextEvent
    {

        public Type Type { get; }
        public string Name { get; }
        public ContentManager Manager { get; }

        public AssetLoadEvent(ContentManager manager, Type assetType, string assetName)
        {
            Manager = manager;
            Type = assetType;
            Name = assetName;
        }
    }
}
