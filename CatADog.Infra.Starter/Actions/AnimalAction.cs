using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Infra.Repositories.NHibernate;

namespace CatADog.Infra.Starter.Actions;

public class AnimalAction : UnitOfWork, IMappingAction<AnimalFormViewModel, Animal>
{
    public void Process(AnimalFormViewModel vm, Animal c, ResolutionContext context)
    {
        if (vm.AdopterId <= 0)
        {
            c.Adopter = null;
            return;
        }

        var repo = GetQueryRepository<Adopter>();
        c.Adopter = repo.Load(vm.AdopterId);
    }
}