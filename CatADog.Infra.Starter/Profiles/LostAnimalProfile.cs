using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Infra.Starter.Actions;

namespace CatADog.Infra.Starter.Profiles;

public class LostAnimalProfile : Profile
{
    public LostAnimalProfile()
    {
        CreateMap<LostAnimal, LostAnimalListViewModel>()
            .ForMember(vm => vm.AddressId, opt => opt.MapFrom(c => c.Address.Id))
            .ForMember(vm => vm.AnimalId, opt => opt.MapFrom(c => c.Animal.Id));

        CreateMap<LostAnimal, LostAnimalFormViewModel>()
            .ForMember(vm => vm.AddressId, opt => opt.MapFrom(c => c.Address.Id))
            .ForMember(vm => vm.AnimalId, opt => opt.MapFrom(c => c.Animal.Id))
            .ReverseMap()
            .AfterMap<LostAnimalAction>();
    }
}