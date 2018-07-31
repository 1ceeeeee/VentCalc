using System;
using Microsoft.EntityFrameworkCore;
using VentCalc.Persistence;

namespace VentCalc.Repositories {
    public interface IUnitOfWork : IDisposable {

        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        void Commit();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext {
        TContext Context { get; }
    }
}