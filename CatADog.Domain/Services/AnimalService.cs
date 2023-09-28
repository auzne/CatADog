using CatADog.Domain.Model.Entities;
using CatADog.Domain.Repositories;
using CatADog.Domain.Validation;

namespace CatADog.Domain.Services;

public class AnimalService : CrudService<Animal>
{
    public AnimalService(IUnitOfWork unitOfWork, Validator<Animal> validator)
        : base(unitOfWork, validator)
    {
    }
}