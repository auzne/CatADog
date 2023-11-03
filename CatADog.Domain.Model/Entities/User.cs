using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.Entities;

public class User : Entity, IAggregateRoot
{
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public virtual string Name { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public virtual string Email { get; set; }

    [Required]
    [StringLength(128, MinimumLength = 6)]
    public virtual string Password { get; set; }
}