using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WasteRegistry.API.Data.DAL.Data.Interfaces;

namespace WasteRegistry.API.Data.DAL.Data
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly WasteRegistrationContext Context = null;

        protected BaseRepository(DbContextOptions<WasteRegistrationContext> options)
        {
            Context = new WasteRegistrationContext(options);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return Context.Find<T>(id);
        }
        public virtual async Task<bool> AddAsync(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            var result = Context.Add<T>(entity);
            await Context.SaveChangesAsync();
            return result.IsKeySet ;
        }
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            var result  = Context.Update<T>(entity);
            await Context.SaveChangesAsync();
            return result.IsKeySet;
        }
    }
}
