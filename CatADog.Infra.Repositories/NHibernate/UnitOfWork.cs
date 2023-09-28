using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using NHibernate;

namespace CatADog.Infra.Repositories.NHibernate;

public class UnitOfWork : IUnitOfWork
{
    private readonly ISession _session = NHibernateHelper.OpenSession();
    private ITransaction? _transaction;

    public IQueryRepository<T> GetQueryRepository<T>() where T : IEntity
    {
        return new QueryRepository<T>(_session);
    }

    public IRepository<T> GetRepository<T>() where T : IAggregateRoot
    {
        return new Repository<T>(_session);
    }

    public void StartTransaction()
    {
        _transaction = _session.BeginTransaction();
    }

    public void CommitTransaction()
    {
        if (_transaction == null) return;

        _transaction.Commit();
        _transaction.Dispose();
        _transaction = null;
    }

    public void RollbackTransaction()
    {
        if (_transaction == null) return;

        _transaction.Rollback();
        _transaction.Dispose();
        _transaction = null;
    }

    public void Dispose()
    {
        if (_session.IsConnected)
            _session.Close();
        _session.Dispose();
    }
}