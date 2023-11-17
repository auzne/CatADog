using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class UserService : CrudService<User>
{
    public UserService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        Validator<User> validator)
        : base(unitOfWork, mapper, validator)
    {
    }

    public Task<UserListViewModel> GetAsViewModelAsync(long id)
    {
        return GetAsViewModelAsync<UserListViewModel>(id);
    }

    public User? FindByEmailAndPassword(string email, string password)
    {
        var repo = UnitOfWork.GetQueryRepository<User>();

        var entity = repo.Query
            .SingleOrDefault(x => x.Email == email && x.Password == password);

        return entity;
    }
}