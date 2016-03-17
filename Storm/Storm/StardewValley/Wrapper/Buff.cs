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

using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class Buff : StaticContextWrapper
    {
        public Buff(StaticContext parent, BuffAccessor accessor) :
            base(parent)
        {
            Underlying = accessor;
        }

        public Buff()
        {
        }

        public int MillisecondsDuration
        {
            get { return Cast<BuffAccessor>()._GetMillisecondsDuration(); }
            set { Cast<BuffAccessor>()._SetMillisecondsDuration(value); }
        }

        public string Description
        {
            get { return Cast<BuffAccessor>()._GetDescription(); }
            set { Cast<BuffAccessor>()._SetDescription(value); }
        }

        public string Source
        {
            get { return Cast<BuffAccessor>()._GetSource(); }
            set { Cast<BuffAccessor>()._SetSource(value); }
        }

        public int Total
        {
            get { return Cast<BuffAccessor>()._GetTotal(); }
            set { Cast<BuffAccessor>()._SetTotal(value); }
        }

        public int SheetIndex
        {
            get { return Cast<BuffAccessor>()._GetSheetIndex(); }
            set { Cast<BuffAccessor>()._SetSheetIndex(value); }
        }

        public int Which
        {
            get { return Cast<BuffAccessor>()._GetWhich(); }
            set { Cast<BuffAccessor>()._SetWhich(value); }
        }

        public Color Glow
        {
            get { return Cast<BuffAccessor>()._GetGlow(); }
            set { Cast<BuffAccessor>()._SetGlow(value); }
        }
    }
}