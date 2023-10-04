using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;

namespace CatADog.Infra.Starter.Profiles;

public class AdopterProfile : Profile
{
    public AdopterProfile()
    {
        CreateMap<Adopter, AdopterListViewModel>();

        CreateMap<Adopter, AdopterFormViewModel>()
            .ForMember(vm => vm.AddressId, opt => opt.MapFrom(c => c.Address.Id))
            .ReverseMap();
    }
}