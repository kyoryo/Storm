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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Json
{
    public class JsonParamContainer
    {
        private JsonInterfaceParams[] interfaceParams = new JsonInterfaceParams[0];
        private JsonFieldDetourParams[] fieldDetourParams = new JsonFieldDetourParams[0];
        private JsonFieldAccessorParams[] fieldAccessorParams = new JsonFieldAccessorParams[0];
        private JsonFieldMutatorParams[] fieldMutatorParams = new JsonFieldMutatorParams[0];
        private JsonFieldAccessorMutatorParams[] fieldAccessorMutatorParams = new JsonFieldAccessorMutatorParams[0];
        private JsonAbsoluteCallParams[] absoluteCallParams = new JsonAbsoluteCallParams[0];
        private JsonFieldInfoParams[] fieldInfoParams = new JsonFieldInfoParams[0];
        private JsonInvokerParams[] invokerParamsParams = new JsonInvokerParams[0];
        private JsonMethodInfoParams[] methodInfoParamsParams = new JsonMethodInfoParams[0];
        private JsonEventCallbackParams[] eventCallbackParams = new JsonEventCallbackParams[0];

        public JsonInterfaceParams[] InterfaceParams { get { return interfaceParams; } set { interfaceParams = value; } }
        public JsonFieldDetourParams[] FieldDetourParams { get { return fieldDetourParams; }set { fieldDetourParams = value; } }
        public JsonFieldAccessorParams[] FieldAccessorParams { get { return fieldAccessorParams;  } set { fieldAccessorParams = value; } }
        public JsonFieldMutatorParams[] FieldMutatorParams { get { return fieldMutatorParams; } set { fieldMutatorParams = value; } }
        public JsonFieldAccessorMutatorParams[] FieldAccessorMutatorParams { get { return fieldAccessorMutatorParams; } set { fieldAccessorMutatorParams = value; } }
        public JsonAbsoluteCallParams[] AbsoluteCallParams { get { return absoluteCallParams; } set { absoluteCallParams = value; } }
        public JsonFieldInfoParams[] FieldInfoParams { get { return fieldInfoParams; } set { fieldInfoParams = value; } }
        public JsonInvokerParams[] InvokerParams { get { return invokerParamsParams; } set { invokerParamsParams = value; } }
        public JsonMethodInfoParams[] MethodInfoParams { get { return methodInfoParamsParams; } set { methodInfoParamsParams = value; } }
        public JsonEventCallbackParams[] EventCallbackParams { get { return eventCallbackParams; } set { eventCallbackParams = value; } }
    }
}
