using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VentCalc.Persistence;

namespace VentCalc.Repositories {
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork
    where TContext : DbContext {
        public UnitOfWork(TContext context) {
            this.Context = context;

        }

        public TContext Context { get; }
        private Dictionary<Type, object> _repositories;

        public IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(Context);
            return (IBaseRepository<TEntity>) _repositories[type];
        }      

        public void Commit() {
            this.Context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    Context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}