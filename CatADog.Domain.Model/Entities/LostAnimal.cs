using System;
using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.Entities;

public class LostAnimal : Entity, IAggregateRoot
{
    [Required] public virtual DateTime Date { get; set; }

    [Required] public virtual bool Found { get; set; }

    [Required] public virtual bool Approved { get; set; }

    [Required] public virtual Animal Animal { get; set; }

    [Required] public virtual Address Address { get; set; }
}