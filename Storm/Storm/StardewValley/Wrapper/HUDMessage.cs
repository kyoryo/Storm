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

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Storm.StardewValley.Accessor;
using Storm.Collections;

namespace Storm.StardewValley.Wrapper
{
    public class HUDMessage : StaticContextWrapper
    {
        public HUDMessage(StaticContext parent, HUDMessageAccessor accessor) : base(parent)
        {
            Underlying = accessor;
        }

        public HUDMessage()
        {
        }

        public System.String Message
        {
            get { return Cast<HUDMessageAccessor>()._GetMessage(); }
            set { Cast<HUDMessageAccessor>()._SetMessage(value); }
        }

        public System.String Type
        {
            get { return Cast<HUDMessageAccessor>()._GetType(); }
            set { Cast<HUDMessageAccessor>()._SetType(value); }
        }

        public Color Color
        {
            get { return Cast<HUDMessageAccessor>()._GetColor(); }
            set { Cast<HUDMessageAccessor>()._SetColor(value); }
        }

        public float TimeLeft
        {
            get { return Cast<HUDMessageAccessor>()._GetTimeLeft(); }
            set { Cast<HUDMessageAccessor>()._SetTimeLeft(value); }
        }

        public float Transparency
        {
            get { return Cast<HUDMessageAccessor>()._GetTransparency(); }
            set { Cast<HUDMessageAccessor>()._SetTransparency(value); }
        }

        public int Number
        {
            get { return Cast<HUDMessageAccessor>()._GetNumber(); }
            set { Cast<HUDMessageAccessor>()._SetNumber(value); }
        }

        public int WhatType
        {
            get { return Cast<HUDMessageAccessor>()._GetWhatType(); }
            set { Cast<HUDMessageAccessor>()._SetWhatType(value); }
        }

        public bool Add
        {
            get { return Cast<HUDMessageAccessor>()._GetAdd(); }
            set { Cast<HUDMessageAccessor>()._SetAdd(value); }
        }

        public bool Achievement
        {
            get { return Cast<HUDMessageAccessor>()._GetAchievement(); }
            set { Cast<HUDMessageAccessor>()._SetAchievement(value); }
        }

        public bool FadeIn
        {
            get { return Cast<HUDMessageAccessor>()._GetFadeIn(); }
            set { Cast<HUDMessageAccessor>()._SetFadeIn(value); }
        }

        public bool NoIcon
        {
            get { return Cast<HUDMessageAccessor>()._GetNoIcon(); }
            set { Cast<HUDMessageAccessor>()._SetNoIcon(value); }
        }
    }
}