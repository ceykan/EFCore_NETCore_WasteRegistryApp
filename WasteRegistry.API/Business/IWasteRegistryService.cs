using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WasteRegistry.API.Data.DML;

namespace WasteRegistry.API.Business
{
    public interface IWasteRegistryService
    {
        Task<bool> Update(WasteRegistryTB request);
        Task<bool> Add(WasteRegistryTB request);
        Task<List<WasteRegistryTB>> GetAll();
        Task<WasteRegistryTB> GetById(int id);
        Task<bool> Delete(int id);
    }
}
