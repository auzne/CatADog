namespace CatADog.Domain.Model.ViewModels;

public class AdopterListViewModel : IViewModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string CPF { get; set; }

    public string PhoneNumber { get; set; }
}