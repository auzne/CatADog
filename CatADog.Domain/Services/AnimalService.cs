using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class AnimalService : CrudService<Animal>
{
    public AnimalService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        Validator<Animal> validator)
        : base(unitOfWork, mapper, validator)
    {
    }

    public Task<AnimalListViewModel> GetAsViewModelAsync(long id)
    {
        return GetAsViewModelAsync<AnimalListViewModel>(id);
    }

    public async Task<IList<AnimalListViewModel>> GetAvailableForAdoptionPagedAsync(int page, int itemsPerPage)
    {
        return await GetPagedAsViewModelAsync(page, itemsPerPage, x => x.Adopter != null);
    }

    public Task<IList<AnimalListViewModel>> GetPagedAsViewModelAsync(int page, int itemsPerPage)
    {
        return GetPagedAsViewModelAsync<AnimalListViewModel>(page, itemsPerPage);
    }

    public Task<IList<AnimalListViewModel>> GetPagedAsViewModelAsync(int page, int itemsPerPage,
        Expression<Func<Animal, bool>> where)
    {
        return GetPagedAsViewModelAsync<AnimalListViewModel>(page, itemsPerPage, where);
    }
}