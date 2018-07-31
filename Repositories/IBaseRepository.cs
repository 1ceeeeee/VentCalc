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
        void Add(T enitity);
        void Delete(T enitity);
        void MarkUpdated(T enitity);

        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetEnumerableAsync();
        Task<IEnumerable<T>> GetEnumerableAsync(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default(CancellationToken));
        Task AddAsync(T enitity, CancellationToken cancellationToken = default(CancellationToken));

    }

}