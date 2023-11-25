using System.Linq;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.Validation;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Security;
using CatADog.Infra.Repositories.NHibernate;

namespace CatADog.Infra.Starter.Actions;

public class UserAction : UnitOfWork, IMappingAction<UserFormViewModel, User>
{
    public void Process(UserFormViewModel vm, User c, ResolutionContext context)
    {
        if (vm.Id > 0)
        {
            // If the User is already in the database, pull the Password, Salt and Iterations
            var repo = GetQueryRepository<User>();

            var fromDatabase = repo.Query
                .SingleOrDefault(x => x.Id == vm.Id && x.Email == vm.Email);

            if (fromDatabase == null)
                throw new ValidatorException("User Id or Email is invalid");

            c.Password = fromDatabase.Password;
            c.Salt = fromDatabase.Salt;
            c.Iterations = fromDatabase.Iterations;
        }
        else
        {
            // Check if there is a password
            if (vm.Password == null)
                throw new ValidatorException("Missing password");

            // When creating a new User, generate the salt, get the iterations and encrypt the password
            c.Salt = CryptoUtils.GenerateSalt();
            c.Iterations = CryptoUtils.DefaultIterations;
            c.Password = CryptoUtils.HashPassword(vm.Password, c.Salt, c.Iterations);
        }
    }
}