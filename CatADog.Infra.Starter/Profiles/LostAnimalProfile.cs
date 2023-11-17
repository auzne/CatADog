using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;

namespace CatADog.Infra.Starter.Profiles;

public class LostAnimalProfile : Profile
{
    public LostAnimalProfile()
    {
        CreateMap<LostAnimal, LostAnimalListViewModel>();

        CreateMap<LostAnimal, LostAnimalFormViewModel>()
            .ReverseMap();
    }
}