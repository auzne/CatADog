namespace CatADog.Domain.Model.Entities;

public class Contact : Entity
{
    public virtual string PhoneNumber { get; set; }

    public virtual Adopter Adopter { get; set; }
}