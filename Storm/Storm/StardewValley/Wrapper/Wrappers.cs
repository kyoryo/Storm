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

namespace Storm.StardewValley.Wrapper
{
    public static class Wrappers
    {
        public class ObjectWrapper : Wrapper
        {
            public object Object { get; set; }

            public ObjectWrapper(object o)
            {
                this.Object = o;
            }

            public override object Expose() => Object;
        }

        public class IntWrapper : Wrapper
        {
            public int Int { get; set; }

            public IntWrapper(int i)
            {
                this.Int = i;
            }

            public override object Expose() => Int;
        }

        public static ObjectWrapper Wrap(object o) => new ObjectWrapper(o);

        public static IntWrapper Wrap(int i) => new IntWrapper(i);
    }
}
