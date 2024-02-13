using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Watch_Store_Management_Web_API.DataAccessLayer.Context;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Implementation
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly WatchStoreDBContext watchStoreDBContext;
        private readonly DbSet<T> dbset;
        public BaseRepository(WatchStoreDBContext watchStoreDBContext)
        {
            this.watchStoreDBContext = watchStoreDBContext;
            dbset = this.watchStoreDBContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            var result = await dbset.AddAsync(entity);
            return result.Entity;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await dbset.FindAsync(id);
            if (entity == null) return await Task.FromResult(false);
            dbset.Remove(entity);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude)
        {
            IQueryable<T> query = dbset;
            if (navsToInclude.Length > 0)
            {
                foreach (var item in navsToInclude)
                {
                    query = query.Include(item);
                }
            }
            var result = query.AsEnumerable();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            var result = dbset.Where(condition);
            return await Task.FromResult(result);
        }

        public async Task<T?> GetById(int id)
        {
            var result = dbset.FindAsync(id);
            return await result;
        }
        public async Task<T?> UpdateAsync(int id, T entity)
        {
            var DBentity = await dbset.FindAsync(id);
            if (DBentity is not null)
            {
                watchStoreDBContext.Entry(DBentity).CurrentValues.SetValues(entity);
                return entity;
            }
            return DBentity;
        }
    }
}
