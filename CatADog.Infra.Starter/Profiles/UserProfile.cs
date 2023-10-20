using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;

namespace CatADog.Infra.Starter.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserListViewModel>();

        CreateMap<User, UserFormViewModel>()
            .ReverseMap();
    }
}