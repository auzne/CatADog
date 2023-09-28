using System;

namespace CatADog.Domain.Model.Entities;

public class AdoptedAnimal : Entity, IAggregateRoot
{
    public virtual DateOnly Date { get; set; }

    public virtual bool Visited { get; set; }

    public virtual Animal Animal { get; set; }

    public virtual Adopter Adopter { get; set; }
}