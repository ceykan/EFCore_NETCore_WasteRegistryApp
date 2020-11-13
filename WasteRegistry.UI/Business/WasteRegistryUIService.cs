using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WasteRegistry.UI.Models;
using Microsoft.Extensions.DependencyInjection;
using WasteRegistry.UI.Business.Interfaces;
using System.Collections.Generic;
using RestSharp;

namespace WasteRegistry.UI.Business
{
    public class WasteRegistryUIService : IWasteRegistryUIService
    {
        protected const string DeleteUri = "/WasteRegistry/Remove";
        protected const string UpdateUri = "/WasteRegistry/Update";
        protected const string AddUri = "/WasteRegistry/Add";
        protected const string GetAllUri = "/WasteRegistry/GetAll";
        protected const string GetByIdUri = "/WasteRegistry/GetById";
        
        private readonly IServiceProvider _provider;
        public WasteRegistryUIService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<bool> Add(WasteRegistryViewModel request)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            var result = _provider.GetService<IBusinessHelper>().ExecuteWasteRegistryApi(requestJson ,AddUri , RestSharp.Method.POST, RestSharp.ParameterType.RequestBody);
            return result.IsSuccessful;
        }

        public async Task<bool> Delete(int id)
        {
            var token = _provider.GetService<IBusinessHelper>().Get_Token();
            var client = new RestClient(string.Format("http://localhost:64423{0}?id={1}" ,DeleteUri, id));
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("Authorization",
            string.Format("Bearer " + token),
                        ParameterType.HttpHeader);
            IRestResponse response = client.Execute(request);
            return response.IsSuccessful;
        }

        public async Task<string> GetAllList()
        {
            
            var result = _provider.GetService<IBusinessHelper>().ExecuteWasteRegistryApi(null, GetAllUri, RestSharp.Method.GET, RestSharp.ParameterType.HttpHeader);
            return result.Content;
        }

        public async Task<string> GetById(int id)
        {
            var token = _provider.GetService<IBusinessHelper>().Get_Token();
            var client = new RestClient(string.Format("http://localhost:64423{0}?id={1}", GetByIdUri, id));
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("Authorization",
            string.Format("Bearer " + token),
                        ParameterType.HttpHeader);
            IRestResponse response =  client.Execute(request);
            return response.Content;
        }

        public async Task<bool> Update(WasteRegistryViewModel request)
        {
            string requestJson = JsonConvert.SerializeObject(request);
            var result = _provider.GetService<IBusinessHelper>().ExecuteWasteRegistryApi(requestJson, UpdateUri, RestSharp.Method.POST, RestSharp.ParameterType.RequestBody);
            return result.IsSuccessful;
        }
    }
}
