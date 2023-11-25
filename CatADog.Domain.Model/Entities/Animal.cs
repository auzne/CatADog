using System.ComponentModel.DataAnnotations;
using CatADog.Domain.Model.Enums;
using CatADog.Domain.Model.ValueObjects;

namespace CatADog.Domain.Model.Entities;

public class Animal : Entity, IAggregateRoot
{
    [StringLength(45, MinimumLength = 40)]
    public virtual string? Microchip { get; set; }

    [Required]
    [StringLength(45, MinimumLength = 2)]
    public virtual string Name { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public virtual string Species { get; set; }

    [Required]
    [StringLength(45, MinimumLength = 3)]
    public virtual string Race { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 2)]
    public virtual string Color { get; set; }

    [Required]
    public virtual Sex Sex { get; set; }

    [Required]
    public virtual bool Ccz { get; set; }

    [Required]
    public virtual Dates Dates { get; set; }

    public virtual Adopter? Adopter { get; set; }
}