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
}