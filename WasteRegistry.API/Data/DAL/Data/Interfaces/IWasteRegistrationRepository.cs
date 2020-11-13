using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WasteRegistry.API.Data.DML;

namespace WasteRegistry.API.Data.DAL.Data.Interfaces
{
    public interface IWasteRegistrationRepository : IBaseRepository<WasteRegistryTB>
    {
        Task<bool> DeleteByIdAsync(int id);
        Task<List<WasteRegistryTB>> GetAll();

    }
}
