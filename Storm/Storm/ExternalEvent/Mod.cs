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

namespace Storm.ExternalEvent
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
