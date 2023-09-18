using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;

namespace CatADog.Domain.Services;

public class AnimalService : CrudService<Animal>
{
    public AnimalService(IUnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }
}