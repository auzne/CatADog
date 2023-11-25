using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CatADog.Domain.Model.Entities;

public class Adopter : Entity, IAggregateRoot
{
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public virtual string FirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public virtual string LastName { get; set; }

    [StringLength(30, MinimumLength = 3)]
    public virtual string? Profession { get; set; }

    [Required]
    [StringLength(12, MinimumLength = 11)]
    public virtual string CPF { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 9)]
    public virtual string RG { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 8)]
    public virtual string PhoneNumber { get; set; }

    [Required]
    public virtual Address Address { get; set; }

    [JsonIgnore]
    public virtual string FullName => $"{FirstName} {LastName}";
}