namespace CatADog.Domain.Model.ViewModels;

public class AdopterListViewModel : IViewModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string? Profession { get; set; }

    public string CPF { get; set; }

    public string RG { get; set; }

    public string PhoneNumber { get; set; }

    public long AddressId { get; set; }
}