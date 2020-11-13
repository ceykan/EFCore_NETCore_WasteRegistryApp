using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WasteRegistry.API.Data.DAL.Data.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
    }
}
