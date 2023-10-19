using System.Threading.Tasks;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class AddressService : CrudService<Address>
{
    public AddressService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        Validator<Address> validator)
        : base(unitOfWork, mapper, validator)
    {
    }

    public Task<AddressListViewModel> GetAsViewModelAsync(long id)
    {
        return GetAsViewModelAsync<AddressListViewModel>(id);
    }
}