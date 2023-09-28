namespace CatADog.Domain.Model.Entities;

public class Contact : Entity, IAggregateRoot
{
    public virtual string PhoneNumber { get; set; }

    public virtual Adopter Adopter { get; set; }
}