using CatADog.Domain.Model.Enums;
using CatADog.Domain.Model.ValueObjects;

namespace CatADog.Domain.Model.Entities;

public class Animal : Entity, IAggregateRoot
{
    public virtual string? Microchip { get; set; }

    public virtual string Species { get; set; }

    public virtual string Race { get; set; }

    public virtual string Color { get; set; }

    public virtual Sex Sex { get; set; }

    public virtual bool Ccz { get; set; }

    public virtual Dates Dates { get; set; }

    public virtual Adopter? Adopter { get; set; }
}