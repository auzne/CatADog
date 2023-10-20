using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class LostAnimalService : CrudService<LostAnimal>
{
    public LostAnimalService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        Validator<LostAnimal> validator)
        : base(unitOfWork, mapper, validator)
    {
    }

    public IList<LostAnimalListViewModel> GetApprovedLostAnimal()
    {
        var repo = UnitOfWork.GetQueryRepository<LostAnimal>();

        var query = repo.Query
            .Where(x => x.Approved);

        var result = Mapper.ProjectTo<LostAnimalListViewModel>(query)
            .ToList();

        return result;
    }

    public IList<LostAnimalListViewModel> GetPendingLostAnimals()
    {
        var repo = UnitOfWork.GetQueryRepository<LostAnimal>();

        var query = repo.Query
            .Where(x => !x.Approved);

        var result = Mapper.ProjectTo<LostAnimalListViewModel>(query)
            .ToList();

        return result;
    }

    public Task<LostAnimalListViewModel> GetAsViewModelAsync(long id)
    {
        return GetAsViewModelAsync<LostAnimalListViewModel>(id);
    }
}