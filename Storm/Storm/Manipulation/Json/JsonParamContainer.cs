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
        private JsonAbsoluteCallParams[] absoluteCallParams = new JsonAbsoluteCallParams[0];
        private JsonFieldInfoParams[] fieldInfoParams = new JsonFieldInfoParams[0];
        private JsonInvokerParams[] invokerParamsParams = new JsonInvokerParams[0];
        private JsonMethodInfoParams[] methodInfoParamsParams = new JsonMethodInfoParams[0];
        private JsonEventCallbackParams[] eventCallbackParams = new JsonEventCallbackParams[0];

        public JsonInterfaceParams[] InterfaceParams { get { return interfaceParams; } set { interfaceParams = value; } }
        public JsonFieldDetourParams[] FieldDetourParams { get { return fieldDetourParams; }set { fieldDetourParams = value; } }
        public JsonFieldAccessorParams[] FieldAccessorParams { get { return fieldAccessorParams;  } set { fieldAccessorParams = value; } }
        public JsonFieldMutatorParams[] FieldMutatorParams { get { return fieldMutatorParams; } set { fieldMutatorParams = value; } }
        public JsonAbsoluteCallParams[] AbsoluteCallParams { get { return absoluteCallParams; } set { absoluteCallParams = value; } }
        public JsonFieldInfoParams[] FieldInfoParams { get { return fieldInfoParams; } set { fieldInfoParams = value; } }
        public JsonInvokerParams[] InvokerParams { get { return invokerParamsParams; } set { invokerParamsParams = value; } }
        public JsonMethodInfoParams[] MethodInfoParams { get { return methodInfoParamsParams; } set { methodInfoParamsParams = value; } }
        public JsonEventCallbackParams[] EventCallbackParams { get { return eventCallbackParams; } set { eventCallbackParams = value; } }
    }
}
