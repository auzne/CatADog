using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;

namespace CatADog.Infra.Starter.Profiles;

public class AnimalProfile : Profile
{
    public AnimalProfile()
    {
        CreateMap<Animal, AnimalListViewModel>();

        CreateMap<Animal, AnimalFormViewModel>()
            .ForMember(vm => vm.AdopterId, opt => opt.Ignore())
            .ReverseMap()
            .AfterMap((vm, c) => vm.AdopterId = c.Adopter?.Id ?? 0);
    }
}