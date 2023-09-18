using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;

namespace CatADog.Domain.Services;

public class QueryService<T> where T : IEntity
{
    protected readonly IUnitOfWork _unitOfWork;

    public QueryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public virtual Task<T> GetAsync(long id)
    {
        var repo = _unitOfWork.GetQueryRepository<T>();
        return repo.GetAsync(id);
    }

    public virtual Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> where)
    {
        var repo = _unitOfWork.GetQueryRepository<T>();
        return repo.GetAllAsync(where);
    }
}