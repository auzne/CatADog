using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using NHibernate;

namespace CatADog.Infra.Repositories.NHibernate;

public class QueryRepository<T> : IQueryRepository<T> where T : IEntity
{
    protected readonly ISession Session;

    public QueryRepository(ISession session)
    {
        Session = session;
    }

    public IQueryable<T> Query => Session.Query<T>();

    public Task<T> GetAsync(object id)
    {
        return Session.GetAsync<T>(id);
    }

    public Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> where)
    {
        return Task.FromResult<IList<T>>(Query.Where(where).ToList());
    }
}