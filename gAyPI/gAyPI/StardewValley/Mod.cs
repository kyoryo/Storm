using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gAyPI.StardewValley
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Mod : Attribute
    {
        private string name;
        private string author;
        private double version;

        public string Name { get { return name; } set { this.name = value; } }

        public string Author { get { return author; } set { this.author = value; } }

        public double Version { get { return version; } set { this.version = value; } }
    }
}
