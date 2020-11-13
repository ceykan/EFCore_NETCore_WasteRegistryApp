using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using WasteRegistry.UI.Business.Interfaces;
using WasteRegistry.UI.Business.Model;

namespace WasteRegistry.UI.Business
{
    public class BusinessHelper : IBusinessHelper
    {
        public string Get_Token()
        {
            string token = string.Empty;
            string uri = @"/Token";
            RestClient restClient = new RestClient("http://localhost:64423");
            try
            {
                string body = JsonConvert.SerializeObject(new User { Username = "DummyUser123", Password = "qwerty124" });
                var request = new RestRequest(uri, Method.POST)
                {
                    RequestFormat = DataFormat.Json
                }.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);

                IRestResponse response = restClient.Execute(request);
                if (!string.IsNullOrEmpty(response.Content))
                {
                    JObject jObject = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
                    token = jObject.SelectToken("token").ToObject<string>();
                }
                return token;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IRestResponse ExecuteWasteRegistryApi(string dataRequest, string uri, Method method, ParameterType type)
        {
            string token = Get_Token();
            RestClient client = new RestClient("http://localhost:64423");
            RestRequest request = new RestRequest(uri, method);
            request.AddParameter("Authorization",
            string.Format("Bearer " + token),
                        ParameterType.HttpHeader);
            if(!string.IsNullOrEmpty(dataRequest))
            request.AddParameter("application/json; charset=utf-8", dataRequest, type); 
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
