using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;

namespace CatADog.Domain.Repositories;

public interface IQueryRepository<T> where T : IEntity
{
    IQueryable<T> Query { get; }
    T Load(object id);
    Task<T> GetAsync(object id);
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> where);
}