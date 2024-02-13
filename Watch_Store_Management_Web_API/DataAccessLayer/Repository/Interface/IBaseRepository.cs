using System.Linq.Expressions;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T?> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition);
    }
}