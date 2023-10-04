using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;

namespace CatADog.Infra.Starter.Profiles;

public class LostAnimalProfile : Profile
{
    public LostAnimalProfile()
    {
        CreateMap<LostAnimal, LostAnimalListViewModel>()
            .ForMember(vm => vm.AddressId, opt => opt.MapFrom(c => c.Address.Id))
            .ForMember(vm => vm.AnimalId, opt => opt.MapFrom(c => c.Animal.Id));
    }
}