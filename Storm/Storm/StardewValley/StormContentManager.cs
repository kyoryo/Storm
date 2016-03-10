/*
    Copyright 2016 Matthew Bell, Cody R (Demmonic)

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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Storm.Manipulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.ExternalEvent;

namespace Storm.StardewValley
{
    public static class StormContentManager
    {
        public static T Load<T>(ContentManager manager, string assetName)
        {
            DetourEvent @event = StaticGameContext.ContentLoadCallback(manager, typeof(T), assetName);
            if (@event.ReturnValue != null)
            {
                return (T)@event.ReturnValue;
            }
            return manager.Load<T>(assetName);
        }

        public static void Unload(ContentManager manager)
        {
            StaticGameContext.ManagerUnloadCallback(manager);
            manager.Unload();
        }
    }
}
