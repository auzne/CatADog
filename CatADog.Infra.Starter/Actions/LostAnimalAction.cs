using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Infra.Repositories.NHibernate;

namespace CatADog.Infra.Starter.Actions;

public class LostAnimalAction : UnitOfWork, IMappingAction<LostAnimalFormViewModel, LostAnimal>
{
    public void Process(LostAnimalFormViewModel vm, LostAnimal c, ResolutionContext context)
    {
        if (vm.AnimalId > 0)
        {
            var repo = GetQueryRepository<Animal>();
            c.Animal = repo.Load(vm.AnimalId);
        }

        if (vm.AddressId > 0)
        {
            var repo = GetQueryRepository<Address>();
            c.Address = repo.Load(vm.AddressId);
        }
    }
}