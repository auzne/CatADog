using System.Collections.Generic;
using System.Linq;
using CatADog.Domain.Model.Validation;

namespace CatADog.Domain.Validation;

public class ValidatorResult
{
    private IList<ValidatorMessage> Errors { get; } = new List<ValidatorMessage>();

    public virtual bool HasErrors => Errors.Any();

    public void AddError(string errorMessage, string? fieldName = null)
    {
        Errors.Add(new ValidatorMessage(errorMessage, fieldName));
    }
}