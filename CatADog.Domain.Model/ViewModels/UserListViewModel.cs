namespace CatADog.Domain.Model.ViewModels;

public class UserListViewModel : IViewModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
}