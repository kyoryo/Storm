using System;

namespace Storm.StardewValley
{
    public class WrappedAccessor : Attribute
    {
        public string SimpleName { get; set; }
    }
}