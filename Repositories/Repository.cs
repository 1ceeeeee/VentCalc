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
            T existing = _dbSet.Find(enitity.Id);
            if (existing != null) _dbSet.Remove(existing); // TODO: переделать с физического удаления на статус
        }
        public void MarkUpdated(T enitity) => _dbSet.Update(enitity);
        public IEnumerable<T> GetEnumerable() => _dbSet.AsEnumerable();
        public IEnumerable<T> GetEnumerable(Expression<System.Func<T, bool>> predicate) => _dbSet.Where(predicate).AsEnumerable();

        public IEnumerable<T> GetEnumerableIcludeMultiple(params Expression<Func<T, object>>[] includes) {
            IQueryable<T> query = _dbSet;
            if (includes != null) {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetEnumerableAsync() => await _dbSet.ToListAsync();
        public Task AddAsync(T enitity) => AddAsync(enitity, cancellationToken : new CancellationToken());
        public Task AddAsync(T enitity, CancellationToken cancellationToken = default(CancellationToken)) => _dbSet.AddAsync(enitity, cancellationToken);
        public async Task DeleteAsync(T enitity) {
            T existing = await _dbSet.FindAsync(enitity.Id);
            if (existing != null) _dbSet.Remove(existing); // TODO: переделать с физического удаления на статус
        }

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetEnumerableAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken)) {
            IQueryable<T> query = _dbSet;
            return await query.Where(predicate).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetEnumerableIcludeMultipleAsync(params Expression<Func<T, object>>[] includes) {
            IQueryable<T> query = _dbSet;
            if (includes != null) {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetEnumerableIcludeMultipleAsync(Expression<System.Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) {
            IQueryable<T> query = _dbSet;
            if (includes != null) {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            if (predicate != null) {
                return await query.Where(predicate).ToListAsync().ConfigureAwait(false);
            }
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetSingleIcludeMultipleAsync(Expression<System.Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) {
            IQueryable<T> query = _dbSet;
            if (includes != null) {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            if (predicate != null) {
                return await query.Where(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
            }
            return await query.SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<T> GetSingleIcludeMultipleAsync(params Expression<Func<T, object>>[] includes) {
            IQueryable<T> query = _dbSet;
            if (includes != null) {
                query = includes.Aggregate(query,
                    (current, include) => current.Include(include));
            }
            return await query.SingleOrDefaultAsync().ConfigureAwait(false);
        }
    }
}