using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteRegistry.UI.Business.Interfaces
{
    public interface IBusinessHelper
    {
        string Get_Token();
        IRestResponse ExecuteWasteRegistryApi(string dataRequest, string uri, Method method, ParameterType type);
    }
}
