namespace CatADog.Domain.Model.ViewModels;

public class AddressFormViewModel : IViewModel
{
    public long Id { get; set; }

    public string Street { get; set; }

    public int? Number { get; set; }

    public string District { get; set; }

    public string State { get; set; }

    public string ZIP { get; set; }

    public string City { get; set; }
}