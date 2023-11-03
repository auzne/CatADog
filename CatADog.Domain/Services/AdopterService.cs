using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatADog.Domain.Model.Dtos;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class AdopterService : CrudService<Adopter>
{
    public AdopterService(
        IUnitOfWork unitOfWork,
        Validator<Adopter> validator)
        : base(unitOfWork, validator)
    {
    }

    public Task<IList<DropDownItem<long>>> GetDropDownList()
    {
        var repo = UnitOfWork.GetQueryRepository<Adopter>();

        var query = repo.Query
            .Select(x => new DropDownItem<long>
            {
                Value = x.Id,
                Text = x.FullName,
                Extra = x.CPF
            })
            .OrderBy(o => o.Text);

        return Task.FromResult<IList<DropDownItem<long>>>(query.ToList());
    }
}