using System.Collections.Generic;
using System.Linq;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class AnimalService : CrudService<Animal>
{
    public AnimalService(
        IUnitOfWork unitOfWork,
        Validator<Animal> validator)
        : base(unitOfWork, validator)
    {
    }

    public IList<Animal> GetAvailableForAdoption(int perPage, int offset)
    {
        var repo = UnitOfWork.GetQueryRepository<Animal>();

        var result = repo.Query
            .Where(x => x.Adopter != null)
            .ToList();

        return result;
    }
}