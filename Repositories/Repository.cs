using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VentCalc.Persistence;

namespace VentCalc.Repositories {
    public class Repository<T> : IBaseRepository<T> where T : BaseEntity {

        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context) {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T enitity) => _dbSet.Add(enitity);

        public void Delete(T enitity) {
            T existing = _dbSet.Find(enitity);
            if (existing != null) _dbSet.Remove(existing); // TODO: переделать с физического удаления на статус
        }
        public void MarkUpdated(T enitity) => _dbSet.Update(enitity);
        public IEnumerable<T> GetEnumerable() => _dbSet.AsEnumerable();
        public IEnumerable<T> GetEnumerable(Expression<System.Func<T, bool>> predicate) => _dbSet.Where(predicate).AsEnumerable();

        public async Task<IEnumerable<T>> GetEnumerableAsync() => await _dbSet.ToListAsync();
        public Task AddAsync(T enitity) => AddAsync(enitity, cancellationToken : new CancellationToken());
        public Task AddAsync(T enitity, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddAsync(enitity, cancellationToken);
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetEnumerableAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken)) {
            IQueryable<T> query = _dbSet;
            return await query.Where(predicate).ToListAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}