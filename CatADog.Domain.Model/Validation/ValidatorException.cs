using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatADog.Domain.Model.Validation;

public class ValidatorException : Exception
{
    public ValidatorException(string message)
        : base(message)
    {
        Errors = new List<ValidatorMessage> { new(message) };
    }

    public ValidatorException(string message, string fieldName)
        : base(message)
    {
        Errors = new List<ValidatorMessage> { new(message, fieldName) };
    }

    public ValidatorException(Exception ex)
        : base(ParseErrors(ex))
    {
        Errors = new List<ValidatorMessage> { new(ParseErrors(ex)) };
    }

    public ValidatorException(Exception ex, string fieldName)
        : base(ParseErrors(ex))
    {
        Errors = new List<ValidatorMessage> { new(ParseErrors(ex), fieldName) };
    }

    public ValidatorException(List<ValidatorMessage> errors)
        : base(ParseErrors(errors))
    {
        Errors = errors;
    }

    public List<ValidatorMessage> Errors { get; }

    private static string ParseErrors(Exception ex)
    {
        return ex.InnerException?.Message ?? ex.Message;
    }

    private static string ParseErrors(IEnumerable<ValidatorMessage> errors)
    {
        var validatorMessages = errors as ValidatorMessage[] ?? errors.ToArray();
        if (!validatorMessages.Any()) return string.Empty;

        var sb = new StringBuilder();
        sb.Append("Errors found:\n");
        foreach (var error in validatorMessages)
            sb.Append($"- {error.Message}\n");

        return sb.ToString();
    }
}