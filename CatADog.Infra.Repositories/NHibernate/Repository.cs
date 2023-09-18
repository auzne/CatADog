using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using NHibernate;

namespace CatADog.Infra.Repositories.NHibernate;

public class Repository<T> : QueryRepository<T>, IRepository<T> where T : IEntity
{
    public Repository(ISession session)
        : base(session)
    {
    }

    public void Insert(T entity)
    {
        Session.Save(entity);
    }

    public async Task InsertAsync(T entity)
    {
        await Session.SaveAsync(entity);
    }

    public void Update(T entity)
    {
        Session.Merge(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await Session.MergeAsync(entity);
    }

    public void Delete(T entity)
    {
        Session.Delete(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        await Session.DeleteAsync(entity);
    }
}