using Core.Abstracts.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Utils
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;

        public Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? expression = null) => await _set.AnyAsync(expression ?? (x => true));

        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null) => await _set.CountAsync(expression ?? (x => true));

        public async Task CreateAsync(T entity) => await _set.AddAsync(entity);

        public void Delete(T entity) => _set.Remove(entity);

        public async Task<T?> ReadFirstAsync(Expression<Func<T, bool>>? expression = null) => await _set.FirstOrDefaultAsync(expression ?? (x => true));

        public async Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>>? expression = null) => await _set.Where(expression ?? (x => true)).ToListAsync();

        public async Task<T?> ReadOneAsync(object entityKey) => await _set.FindAsync(entityKey);

        public void Update(T entity) => _set.Update(entity);
    }
}
