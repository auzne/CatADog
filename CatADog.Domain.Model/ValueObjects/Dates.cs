using System;

namespace CatADog.Domain.Model.ValueObjects;

public class Dates : ValueObject<Dates>
{
    public virtual DateOnly? Age { get; set; }

    public virtual DateOnly Dewormed { get; set; }

    public virtual DateOnly Neutered { get; set; }

    public virtual DateOnly Vaccinated { get; set; }
}