using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WasteRegistry.API.Business;
using WasteRegistry.API.Data.DML;

namespace WasteRegistry.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class WasteRegistryController : ControllerBase
    {
        private readonly IServiceProvider _provider;
        public WasteRegistryController(IServiceProvider provider)
        {
            this._provider = provider;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<WasteRegistryTB>> GetAll()
        {
            using var scope = _provider.CreateScope();
            return await _provider.GetService<IWasteRegistryService>().GetAll();
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<WasteRegistryTB> GetById(int id)
        {
            using (var scope = _provider.CreateScope())
            {
                return await _provider.GetService<IWasteRegistryService>().GetById(id);
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<bool> Update([FromBody] WasteRegistryTB request)
        {
            using (var scope = _provider.CreateScope())
            {
                return await _provider.GetService<IWasteRegistryService>().Update(request);
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<bool> Add([FromBody] WasteRegistryTB request)
        {
            using (var scope = _provider.CreateScope())
            {
                return await _provider.GetService<IWasteRegistryService>().Add(request);
            }
        }

        [HttpPost]
        [Route("Remove")]
        public async Task<bool> Remove(int id)
        {
            using (var scope = _provider.CreateScope())
            {
                return await _provider.GetService<IWasteRegistryService>().Delete(id);
            }
        }
    }
}