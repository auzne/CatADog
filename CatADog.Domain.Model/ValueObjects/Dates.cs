using System;

namespace CatADog.Domain.Model.ValueObjects;

public class Dates : ValueObject<Dates>
{
    public virtual DateTime? Age { get; set; }

    public virtual DateTime Dewormed { get; set; }

    public virtual DateTime Neutered { get; set; }

    public virtual DateTime Vaccinated { get; set; }

    public virtual DateTime? Adoption { get; set; }
}