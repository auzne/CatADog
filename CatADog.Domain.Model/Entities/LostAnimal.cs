using System;

namespace CatADog.Domain.Model.Entities;

public class LostAnimal : Entity, IAggregateRoot
{
    public virtual DateOnly Date { get; set; }

    public virtual bool Found { get; set; }

    public virtual bool Approved { get; set; }

    public virtual Animal Animal { get; set; }

    public virtual Address Address { get; set; }
}