using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatADog.Domain.Model.ValueObjects;

namespace CatADog.Domain.Validation;

public static class AnnotationsValidator
{
    public static void ValidateAnnotations<T>(this ValidatorResult result, T entity, string namePrefix = "")
    {
        if (entity == null)
            return;

        var ctx = new ValidationContext(entity);

        var type = entity.GetType();
        var props = type.GetProperties();

        foreach (var prop in props)
        {
            var value = prop.GetValue(entity, null);

            if (value != null && prop.PropertyType.BaseType?.Name == typeof(ValueObject<>).Name)
                // Validates properties of a Value Object that have the Required annotation
                if (Attribute.IsDefined(prop, typeof(RequiredAttribute)))
                {
                    namePrefix += prop.Name + ".";
                    result.ValidateAnnotations(value, namePrefix);
                }

            ctx.MemberName = prop.Name;
            var validationList = new List<ValidationResult>();
            Validator.TryValidateProperty(value, ctx, validationList);

            foreach (var validation in validationList)
                result.AddError(
                    validation?.ErrorMessage ?? string.Empty,
                    prop.ReflectedType?.BaseType?.Name == typeof(ValueObject<>).Name
                        ? namePrefix + prop.Name
                        : prop.Name);
        }
    }
}