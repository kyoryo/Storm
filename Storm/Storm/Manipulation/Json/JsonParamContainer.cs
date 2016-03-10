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

namespace Storm.Manipulation.Json
{
    public class JsonParamContainer
    {
        public JsonInterfaceParams[] InterfaceParams { get; set; } = new JsonInterfaceParams[0];
        public JsonFieldDetourParams[] FieldDetourParams { get; set; } = new JsonFieldDetourParams[0];
        public JsonFieldAccessorParams[] FieldAccessorParams { get; set; } = new JsonFieldAccessorParams[0];
        public JsonFieldMutatorParams[] FieldMutatorParams { get; set; } = new JsonFieldMutatorParams[0];
        public JsonFieldAccessorMutatorParams[] FieldAccessorMutatorParams { get; set; } = new JsonFieldAccessorMutatorParams[0];
        public JsonAbsoluteCallParams[] AbsoluteCallParams { get; set; } = new JsonAbsoluteCallParams[0];
        public JsonFieldInfoParams[] FieldInfoParams { get; set; } = new JsonFieldInfoParams[0];
        public JsonInvokerParams[] InvokerParams { get; set; } = new JsonInvokerParams[0];
        public JsonMethodInfoParams[] MethodInfoParams { get; set; } = new JsonMethodInfoParams[0];
        public JsonEventCallbackParams[] EventCallbackParams { get; set; } = new JsonEventCallbackParams[0];
    }
}