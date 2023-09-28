using System;

namespace CatADog.Domain.Model.Validation;

public class ValidatorMessage
{
    public ValidatorMessage(string message, string? key = null)
    {
        Message = message;
        Key = key;
    }

    public ValidatorMessage(Exception ex, string? key = null)
    {
        Message = ex.Message;
        Key = key;
    }

    public string Message { get; set; }
    public string? Key { get; set; }
}