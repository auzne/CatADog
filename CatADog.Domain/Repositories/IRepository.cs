using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;

namespace CatADog.Domain.Repositories;

public interface IRepository<T> : IQueryRepository<T> where T : IAggregateRoot
{
    void Insert(T entity);
    Task InsertAsync(T entity);
    void Update(T entity);
    Task UpdateAsync(T entity);
    void Delete(T entity);
    Task DeleteAsync(T entity);
}