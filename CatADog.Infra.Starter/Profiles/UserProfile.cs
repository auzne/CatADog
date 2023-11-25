using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Infra.Starter.Actions;

namespace CatADog.Infra.Starter.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserListViewModel>();

        CreateMap<User, UserFormViewModel>()
            .ForMember(vm => vm.Password, cfg => cfg.Ignore())
            .ReverseMap()
            .ForMember(e => e.Password, cfg => cfg.Ignore())
            .AfterMap<UserAction>();
    }
}