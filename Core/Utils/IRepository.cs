using Core.Abstracts.Bases;
using System.Linq.Expressions;

namespace Core.Utils
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task<T?> ReadOneAsync(object entityKey);
        Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>>? expression = null);
        Task<T?> ReadFirstAsync(Expression<Func<T, bool>>? expression = null);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? expression = null);
    }
}
