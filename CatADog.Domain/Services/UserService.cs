using System.Linq;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class UserService : CrudService<User>
{
    public UserService(
        IUnitOfWork unitOfWork,
        Validator<User> validator)
        : base(unitOfWork, validator)
    {
    }

    public User? FindByEmailAndPassword(string email, string password)
    {
        var repo = UnitOfWork.GetQueryRepository<User>();

        var entity = repo.Query
            .SingleOrDefault(x => x.Email == email && x.Password == password);

        return entity;
    }
}