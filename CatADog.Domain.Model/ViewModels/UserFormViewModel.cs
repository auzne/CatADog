namespace CatADog.Domain.Model.ViewModels;

public class UserFormViewModel : IViewModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}