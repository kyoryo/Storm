﻿using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class ManagerUnloadEvent : StaticContextEvent
    {
        public ContentManager Manager { get; }

        public ManagerUnloadEvent(ContentManager manager)
        {
            Manager = manager;
        }
    }
}