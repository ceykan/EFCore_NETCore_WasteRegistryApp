using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WasteRegistry.API.Data.DAL.Data.Interfaces;
using WasteRegistry.API.Data.DML;
using Microsoft.Extensions.DependencyInjection;

namespace WasteRegistry.API.Business
{
    public class WasteRegistryService : IWasteRegistryService
    {
        private readonly IServiceProvider _provider;
        public WasteRegistryService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<bool> Add(WasteRegistryTB request)
        {
            return await _provider.GetService<IWasteRegistrationRepository>().AddAsync(request);
        }

        public async Task<bool> Delete(int id)
        {
            return await _provider.GetService<IWasteRegistrationRepository>().DeleteByIdAsync(id);
        }

        public async Task<List<WasteRegistryTB>> GetAll()
        {
            return await _provider.GetService<IWasteRegistrationRepository>().GetAll();
        }

        public async Task<WasteRegistryTB> GetById(int id)
        {
            return await _provider.GetService<IWasteRegistrationRepository>().GetByIdAsync(id);
        }

        public async Task<bool> Update(WasteRegistryTB request)
        {
            return await _provider.GetService<IWasteRegistrationRepository>().UpdateAsync(request);
        }
    }
}
