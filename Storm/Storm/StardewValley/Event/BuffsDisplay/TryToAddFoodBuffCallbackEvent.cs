﻿/*
    Copyright 2016

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

using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event
{
    public class TryToAddFoodBuffCallbackEvent : StaticContextEvent
    {
        public TryToAddFoodBuffCallbackEvent(BuffsDisplay buffsDisplay, Buff buff, int duration)
        {
            BuffsDisplay = buffsDisplay;
            Buff = buff;
            Duration = duration;
        }

        public BuffsDisplay BuffsDisplay { get; }
        public Buff Buff { get; }
        public int Duration { get; }
    }
}