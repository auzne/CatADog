using System.Collections.Generic;
using System.Threading.Tasks;
using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.Enums;

namespace CatADog.Domain.Validation;

public class Validator<T> where T : IAggregateRoot
{
    public async Task<ValidatorResult> Validate(T entity, ValidationType type = ValidationType.Default)
    {
        var result = new ValidatorResult();

        await Validate(result, entity, type);

        return result;
    }

    public async Task<ValidatorResult> Validate(T[] entities, ValidationType type = ValidationType.Default)
    {
        var result = new ValidatorResult();
        var validateList = new List<Task>();

        foreach (var entity in entities)
            validateList.Add(Validate(result, entity, type));

        await Task.WhenAll(validateList);

        return result;
    }

    private async Task Validate(ValidatorResult result, T entity, ValidationType type)
    {
        switch (type)
        {
            case ValidationType.Default:
                await DefaultValidations(result, entity);
                break;
            case ValidationType.Insert:
                await InsertValidations(result, entity);
                break;
            case ValidationType.Update:
                await UpdateValidations(result, entity);
                break;
            case ValidationType.Delete:
                await DeleteValidations(result);
                break;
            default:
                await DefaultValidations(result, entity);
                break;
        }
    }

    protected virtual void AnnotationsValidations(ValidatorResult result, T entity)
    {
        result.ValidateAnnotations(entity);
    }

    protected virtual Task DefaultValidations(ValidatorResult result, T entity)
    {
        if (entity == null)
            result.AddError("Entity is null!");
        else
            AnnotationsValidations(result, entity);

        return Task.CompletedTask;
    }

    protected virtual Task InsertValidations(ValidatorResult result, T entity)
    {
        return DefaultValidations(result, entity);
    }

    protected virtual Task UpdateValidations(ValidatorResult result, T entity)
    {
        return DefaultValidations(result, entity);
    }

    protected virtual Task DeleteValidations(ValidatorResult result)
    {
        return Task.CompletedTask;
    }
}