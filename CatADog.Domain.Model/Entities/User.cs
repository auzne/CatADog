namespace CatADog.Domain.Model.Entities;

public class User : Entity
{
    public virtual string UserName { get; set; }

    public virtual string Password { get; set; }

    public virtual string FirstName { get; set; }

    public virtual string LastName { get; set; }

    public virtual string Email { get; set; }
}