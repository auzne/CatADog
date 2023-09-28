using System;
using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;

namespace CatADog.Domain.Services;

public class CrudService<T> : QueryService<T> where T : IAggregateRoot
{
    public CrudService(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    public virtual async Task InsertAsync(T entity)
    {
        try
        {
            var repo = _unitOfWork.GetRepository<T>();

            _unitOfWork.StartTransaction();
            await repo.InsertAsync(entity);
            _unitOfWork.CommitTransaction();
        }
        catch (Exception)
        {
            _unitOfWork.RollbackTransaction();
            throw;
        }
    }

    public virtual async Task UpdateAsync(T entity)
    {
        try
        {
            var repo = _unitOfWork.GetRepository<T>();

            _unitOfWork.StartTransaction();
            await repo.UpdateAsync(entity);
            _unitOfWork.CommitTransaction();
        }
        catch (Exception)
        {
            _unitOfWork.RollbackTransaction();
            throw;
        }
    }

    public virtual async Task DeleteAsync(T entity)
    {
        try
        {
            var repo = _unitOfWork.GetRepository<T>();

            _unitOfWork.StartTransaction();
            await repo.DeleteAsync(entity);
            _unitOfWork.CommitTransaction();
        }
        catch (Exception)
        {
            _unitOfWork.RollbackTransaction();
            throw;
        }
    }
}