using System;
using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;

namespace CatADog.Domain.Services;

public class CrudService<T> : QueryService<T> where T : IEntity
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

            _unitOfWork.Start();
            await repo.InsertAsync(entity);
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public virtual async Task UpdateAsync(T entity)
    {
        try
        {
            var repo = _unitOfWork.GetRepository<T>();

            _unitOfWork.Start();
            await repo.UpdateAsync(entity);
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    public virtual async Task DeleteAsync(T entity)
    {
        try
        {
            var repo = _unitOfWork.GetRepository<T>();

            _unitOfWork.Start();
            await repo.DeleteAsync(entity);
            _unitOfWork.Commit();
        }
        catch (Exception)
        {
            _unitOfWork.Rollback();
            throw;
        }
    }
}