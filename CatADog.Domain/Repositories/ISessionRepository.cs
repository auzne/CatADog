using System;
using CatADog.Domain.Model.Entities;

namespace CatADog.Domain.Repositories;

public interface ISessionRepository : IDisposable
{
    IQueryRepository<T> GetQueryRepository<T>() where T : IEntity;
    IRepository<T> GetRepository<T>() where T : IEntity;

    void StartTransaction();
    void CommitTransaction();
    void RollbackTransaction();
}