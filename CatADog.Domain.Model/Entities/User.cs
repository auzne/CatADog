using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.Entities;

public class User : Entity, IAggregateRoot
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public virtual string Name { get; set; }

    [Required]
    [EmailAddress]
    public virtual string Email { get; set; }

    [Required]
    public virtual byte[] Password { get; set; }

    [Required]
    public virtual byte[] Salt { get; set; }

    [Required]
    public virtual int Iterations { get; set; }
}