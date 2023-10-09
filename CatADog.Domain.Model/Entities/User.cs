namespace CatADog.Domain.Model.Entities;

public class User : Entity, IAggregateRoot
{
    public virtual string Name { get; set; }

    public virtual string Email { get; set; }

    public virtual string Password { get; set; }
}