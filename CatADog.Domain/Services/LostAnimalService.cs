using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Repositories;

namespace CatADog.Domain.Services;

public class LostAnimalService : QueryService<LostAnimal>
{
    public LostAnimalService(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    {
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
}