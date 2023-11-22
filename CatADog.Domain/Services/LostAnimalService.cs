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

public class LostAnimalService : CrudService<LostAnimal>
{
    public LostAnimalService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        Validator<LostAnimal> validator)
        : base(unitOfWork, mapper, validator)
    {
    }

    public Task<LostAnimalListViewModel> GetAsViewModelAsync(long id)
    {
        return GetAsViewModelAsync<LostAnimalListViewModel>(id);
    }

    public async Task<IList<LostAnimalListViewModel>> GetApprovedLostAnimalPagedAsync(int page, int itemsPerPage)
    {
        return await GetPagedAsViewModelAsync(page, itemsPerPage, x => x.Approved);
    }

    public async Task<IList<LostAnimalListViewModel>> GetPendingLostAnimalsPagedAsync(int page, int itemsPerPage)
    {
        return await GetPagedAsViewModelAsync(page, itemsPerPage, x => !x.Approved);
    }

    public Task<IList<LostAnimalListViewModel>> GetPagedAsViewModelAsync(int page, int itemsPerPage)
    {
        return GetPagedAsViewModelAsync<LostAnimalListViewModel>(page, itemsPerPage);
    }

    public Task<IList<LostAnimalListViewModel>> GetPagedAsViewModelAsync(int page, int itemsPerPage,
        Expression<Func<LostAnimal, bool>> where)
    {
        return GetPagedAsViewModelAsync<LostAnimalListViewModel>(page, itemsPerPage, where);
    }
}