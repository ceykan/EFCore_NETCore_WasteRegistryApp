using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WasteRegistry.API.Data.DAL.Data.Interfaces;
using WasteRegistry.API.Data.DML;

namespace WasteRegistry.API.Data.DAL.Data
{
    public class WasteRegistrationRepository : BaseRepository<WasteRegistryTB>, IWasteRegistrationRepository
    {
        public WasteRegistrationRepository(DbContextOptions<WasteRegistrationContext> options) : base(options)
        {

        }

        public virtual async Task<List<WasteRegistryTB>> GetAll()
        {
            return Context.WasteRegistryTB.ToList();
        }
        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            var wasteData = new WasteRegistryTB { Id = id };
            Context.Entry(wasteData).State = EntityState.Deleted;
            var count = await Context.SaveChangesAsync();
            return count > 0 ? true : false;
        }
    }
}
