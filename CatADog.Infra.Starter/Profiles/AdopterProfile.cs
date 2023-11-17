using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Infra.Starter.Actions;

namespace CatADog.Infra.Starter.Profiles;

public class AdopterProfile : Profile
{
    public AdopterProfile()
    {
        CreateMap<Adopter, AdopterListViewModel>()
            .ForMember(vm => vm.Name, opt => opt.MapFrom(c => c.FullName));

        CreateMap<Adopter, AdopterFormViewModel>()
            .ForMember(vm => vm.AddressId, opt => opt.MapFrom(c => c.Address.Id))
            .ReverseMap()
            .AfterMap<AdopterAction>();
    }
}