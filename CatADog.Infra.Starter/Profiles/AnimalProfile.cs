using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Infra.Starter.Actions;

namespace CatADog.Infra.Starter.Profiles;

public class AnimalProfile : Profile
{
    public AnimalProfile()
    {
        CreateMap<Animal, AnimalListViewModel>()
            .ForMember(vm => vm.AdopterId, opt => opt.MapFrom(c => c.Adopter == null ? 0 : c.Adopter.Id));

        CreateMap<Animal, AnimalFormViewModel>()
            .ForMember(vm => vm.AdopterId, opt => opt.MapFrom(c => c.Adopter == null ? 0 : c.Adopter.Id))
            .ReverseMap()
            .AfterMap<AnimalAction>();
    }
}