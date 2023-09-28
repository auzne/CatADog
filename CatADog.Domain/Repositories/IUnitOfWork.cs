using System;
using CatADog.Domain.Model.Entities;

namespace CatADog.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IQueryRepository<T> GetQueryRepository<T>() where T : IEntity;
    IRepository<T> GetRepository<T>() where T : IAggregateRoot;

    void StartTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}