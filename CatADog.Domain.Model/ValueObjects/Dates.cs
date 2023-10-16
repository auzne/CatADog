using System;

namespace CatADog.Domain.Model.ValueObjects;

public class Dates : ValueObject<Dates>
{
    public virtual DateTimeOffset? Age { get; set; }

    public virtual DateTimeOffset Dewormed { get; set; }

    public virtual DateTimeOffset Neutered { get; set; }

    public virtual DateTimeOffset Vaccinated { get; set; }

    public virtual DateTimeOffset? Adoption { get; set; }
}