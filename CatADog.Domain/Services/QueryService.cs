using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
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

    public virtual Task<IList<T>> GetPagedAsync(int page, int itemsPerPage)
    {
        var repo = UnitOfWork.GetQueryRepository<T>();

        var query = repo.Query
            .Skip(itemsPerPage * page)
            .Take(itemsPerPage);

        return Task.FromResult<IList<T>>(query.ToList());
    }

    public virtual Task<IList<T>> GetPagedAsync(int page, int itemsPerPage, Expression<Func<T, bool>> where)
    {
        var repo = UnitOfWork.GetQueryRepository<T>();

        var query = repo.Query
            .Skip(itemsPerPage * page)
            .Take(itemsPerPage)
            .Where(where);

        return Task.FromResult<IList<T>>(query.ToList());
    }

    public virtual Task<IList<TVm>> GetPagedAsViewModelAsync<TVm>(int page, int itemsPerPage)
        where TVm : IViewModel
    {
        var repo = UnitOfWork.GetQueryRepository<T>();

        var query = repo.Query
            .Skip(itemsPerPage * page)
            .Take(itemsPerPage);

        return Task.FromResult<IList<TVm>>(Mapper.ProjectTo<TVm>(query).ToList());
    }

    public virtual Task<IList<TVm>> GetPagedAsViewModelAsync<TVm>(int page, int itemsPerPage,
        Expression<Func<T, bool>> where)
        where TVm : IViewModel
    {
        var repo = UnitOfWork.GetQueryRepository<T>();

        var query = repo.Query
            .Skip(itemsPerPage * page)
            .Take(itemsPerPage)
            .Where(where);

        return Task.FromResult<IList<TVm>>(Mapper.ProjectTo<TVm>(query).ToList());
    }
}