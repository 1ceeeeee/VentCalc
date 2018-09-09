using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VentCalc.Persistence;

namespace VentCalc.Repositories {
    public interface IBaseRepository<T> where T : BaseEntity {
        IEnumerable<T> GetEnumerable();
        IEnumerable<T> GetEnumerable(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetEnumerableIcludeMultiple(params Expression<Func<T, object>>[] includes);
        void Add(T enitity);
        void Delete(T enitity);
        void MarkUpdated(T enitity);

        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetEnumerableAsync();
        Task<IEnumerable<T>> GetEnumerableAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<T>> GetEnumerableIcludeMultipleAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetEnumerableIcludeMultipleAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T enitity, CancellationToken cancellationToken = default(CancellationToken));

    }

}