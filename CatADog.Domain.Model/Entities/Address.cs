using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.Entities;

public class Address : Entity, IAggregateRoot
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public virtual string Street { get; set; }

    public virtual int? Number { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public virtual string District { get; set; }

    [Required]
    [StringLength(3, MinimumLength = 1)]
    public virtual string State { get; set; }

    [Required]
    [StringLength(9, MinimumLength = 8)]
    public virtual string ZIP { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public virtual string City { get; set; }
}