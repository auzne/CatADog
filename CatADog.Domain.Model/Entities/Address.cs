namespace CatADog.Domain.Model.Entities;

public class Address : Entity
{
    public virtual string Street { get; set; }

    public virtual int? Number { get; set; }

    public virtual string District { get; set; }

    public virtual string State { get; set; }

    public virtual string ZIP { get; set; }

    public virtual string City { get; set; }
}