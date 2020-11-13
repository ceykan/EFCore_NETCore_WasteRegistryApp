using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WasteRegistry.UI.Models;

namespace WasteRegistry.UI.Business.Interfaces
{
    public interface IWasteRegistryUIService
    {
        Task<string> GetAllList();
        Task<bool> Update(WasteRegistryViewModel request);
        Task<bool> Add(WasteRegistryViewModel request);
        Task<string> GetById(int id);
        Task<bool> Delete(int id);
    }
}
