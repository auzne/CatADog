using System.Collections.Generic;
using System.Linq;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class LostAnimalService : CrudService<LostAnimal>
{
    public LostAnimalService(
        IUnitOfWork unitOfWork,
        Validator<LostAnimal> validator)
        : base(unitOfWork, validator)
    {
    }

    public IList<LostAnimal> GetApprovedLostAnimal()
    {
        var repo = UnitOfWork.GetQueryRepository<LostAnimal>();

        var result = repo.Query
            .Where(x => x.Approved)
            .ToList();

        return result;
    }

    public IList<LostAnimal> GetPendingLostAnimals()
    {
        var repo = UnitOfWork.GetQueryRepository<LostAnimal>();

        var result = repo.Query
            .Where(x => !x.Approved)
            .ToList();

        return result;
    }
}