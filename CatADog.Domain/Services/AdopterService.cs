using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.ValueObjects;
using CatADog.Domain.Model.ViewModels;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class AdopterService : CrudService<Adopter>
{
    public AdopterService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        Validator<Adopter> validator)
        : base(unitOfWork, mapper, validator)
    {
    }

    public Task<AdopterListViewModel> GetAsViewModelAsync(long id)
    {
        return GetAsViewModelAsync<AdopterListViewModel>(id);
    }

    public Task<IList<DropDownItem<long>>> GetDropDownList()
    {
        var repo = UnitOfWork.GetQueryRepository<Adopter>();

        var query = repo.Query
            .Select(x => new DropDownItem<long>(x.Id, x.FullName, x.CPF))
            .OrderBy(o => o.Text);

        return Task.FromResult<IList<DropDownItem<long>>>(query.ToList());
    }
}