using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CatADog.Domain.Model.Dtos;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Repositories;
using CatADog.Domain.Security;
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

    public byte[]? GetPassword(long id)
    {
        var repo = UnitOfWork.GetQueryRepository<User>();

        var entity = repo.Query
            .SingleOrDefault(x => x.Id == id);

        return entity?.Password;
    }

    public byte[]? GetPassword(string email)
    {
        var repo = UnitOfWork.GetQueryRepository<User>();

        var entity = repo.Query
            .SingleOrDefault(x => x.Email == email);

        return entity?.Password;
    }

    public byte[]? GetSalt(long id)
    {
        var repo = UnitOfWork.GetQueryRepository<User>();

        var entity = repo.Query
            .SingleOrDefault(x => x.Id == id);

        return entity?.Salt;
    }

    public byte[]? GetSalt(string email)
    {
        var repo = UnitOfWork.GetQueryRepository<User>();

        var entity = repo.Query
            .SingleOrDefault(x => x.Email == email);

        return entity?.Salt;
    }

    public User? FindByEmailAndPassword(string email, string password)
    {
        var repo = UnitOfWork.GetQueryRepository<User>();

        var entity = repo.Query
            .SingleOrDefault(x => x.Email == email);

        if (entity == null)
            return null;

        // encrypt and compare the password
        var encryptedPassword = CryptoUtils.HashPassword(password, entity.Salt, entity.Iterations);
        var samePassword = entity.Password.SequenceEqual(encryptedPassword);

        return samePassword ? entity : null;
    }

    public Task<UserFormViewModel> InsertViewModelAsync(UserFormViewModel viewModel)
    {
        var repo = UnitOfWork.GetQueryRepository<User>();

        var fromDatabase = repo.Query
            .SingleOrDefault(x => x.Email == viewModel.Email);

        if (fromDatabase != null)
            throw new ConstraintException("The Email is already in use");

        viewModel.Id = 0;

        // encrypted password, salt and iterations are acquired when mapping to User
        return base.InsertViewModelAsync(viewModel);
    }

    public async Task<bool> UpdatePassword(ChangePasswordDto dto)
    {
        var user = FindByEmailAndPassword(dto.Email, dto.Password);

        if (user == null)
            return false;

        // Update salt, iterations and password
        user.Salt = CryptoUtils.GenerateSalt();
        user.Iterations = CryptoUtils.DefaultIterations;
        user.Password = CryptoUtils.HashPassword(dto.NewPassword, user.Salt, user.Iterations);

        await UpdateAsync(user);
        return true;
    }
}