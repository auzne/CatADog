using System;
using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class CrudService<T> : QueryService<T> where T : IAggregateRoot
{
    public CrudService(IUnitOfWork unitOfWork, Validator<T> validator)
        : base(unitOfWork)
    {
        Validator = validator;
    }

    protected virtual Validator<T> Validator { get; }

    public virtual async Task<T> InsertAsync(T entity)
    {
        try
        {
            var repo = UnitOfWork.GetRepository<T>();

            UnitOfWork.StartTransaction();
            await repo.InsertAsync(entity);
            UnitOfWork.CommitTransaction();

            return entity;
        }
        catch (Exception)
        {
            UnitOfWork.RollbackTransaction();
            throw;
        }
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        try
        {
            var repo = UnitOfWork.GetRepository<T>();

            UnitOfWork.StartTransaction();
            await repo.UpdateAsync(entity);
            UnitOfWork.CommitTransaction();

            return entity;
        }
        catch (Exception)
        {
            UnitOfWork.RollbackTransaction();
            throw;
        }
    }

    public virtual async Task DeleteAsync(T entity)
    {
        try
        {
            var repo = UnitOfWork.GetRepository<T>();

            UnitOfWork.StartTransaction();
            await repo.DeleteAsync(entity);
            UnitOfWork.CommitTransaction();
        }
        catch (Exception)
        {
            UnitOfWork.RollbackTransaction();
            throw;
        }
    }
}