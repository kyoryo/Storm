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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Json
{
    public class JsonEventCallbackParams
    {
        private string instanceCallbackName = string.Empty;
        private string instanceCallbackDesc = string.Empty;
        private string staticCallbackName = string.Empty;
        private string staticCallbackDesc = string.Empty;

        public string OwnerAccessorType { get; set; }
        public string OwnerMethodName { get; set; }
        public string OwnerMethodDesc { get; set; }
        public string CallbackType { get; set; }
        public string InstanceCallbackName { get { return instanceCallbackName; } set { instanceCallbackName = value; } }
        public string InstanceCallbackDesc { get { return instanceCallbackDesc; } set { instanceCallbackDesc = value; } }
        public string StaticCallbackName { get { return staticCallbackName; } set { staticCallbackName = value; } }
        public string StaticCallbackDesc { get { return staticCallbackDesc; } set { staticCallbackDesc = value; } }
        public bool PushParams { get; set; }
        public InsertionType InsertionType { get; set; }
        public int[] InsertionIndex { get; set; }
    }
}
