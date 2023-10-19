using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Infra.Repositories.NHibernate;

namespace CatADog.Infra.Starter.Actions;

public class AdopterAction : UnitOfWork, IMappingAction<AdopterFormViewModel, Adopter>
{
    public void Process(AdopterFormViewModel vm, Adopter c, ResolutionContext context)
    {
        if (vm.AddressId <= 0)
            return;

        var repo = GetQueryRepository<Address>();
        c.Address = repo.Load(vm.AddressId);
    }
}