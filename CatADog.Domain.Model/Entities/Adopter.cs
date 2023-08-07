namespace CatADog.Domain.Model.Entities;

public class Adopter : Entity
{
    public virtual string FirstName { get; set; }
    
    public virtual string LastName { get; set; }
    
    public virtual string Profession { get; set; }
    
    public virtual string CPF { get; set; }
    
    public virtual string RG { get; set; }
    
    public virtual Address Address { get; set; }
}