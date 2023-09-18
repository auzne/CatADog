using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using NHibernate;

namespace CatADog.Infra.Repositories.NHibernate;

public class SessionRepository : ISessionRepository
{
    private readonly ISession _session;
    private ITransaction? _transaction;

    public SessionRepository(ISession session)
    {
        _session = session;
    }

    public IQueryRepository<T> GetQueryRepository<T>() where T : IEntity
    {
        return new QueryRepository<T>(_session);
    }

    public IRepository<T> GetRepository<T>() where T : IEntity
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
    }

    public void RollbackTransaction()
    {
        if (_transaction == null) return;

        _transaction.Rollback();
        _transaction.Dispose();
    }

    public void Dispose()
    {
        _session.Close();
    }
}