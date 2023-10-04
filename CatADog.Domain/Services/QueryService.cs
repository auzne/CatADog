using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;

namespace CatADog.Domain.Services;

public class QueryService<T> where T : IEntity
{
    protected readonly IMapper Mapper;
    protected readonly IUnitOfWork UnitOfWork;

    public QueryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    public virtual Task<T> GetAsync(long id)
    {
        var repo = UnitOfWork.GetQueryRepository<T>();
        return repo.GetAsync(id);
    }

    public virtual Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> where)
    {
        var repo = UnitOfWork.GetQueryRepository<T>();
        return repo.GetAllAsync(where);
    }
}