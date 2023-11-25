using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.ViewModels;

public class UserFormViewModel : IViewModel
{
    public long Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [PasswordPropertyText]
    public string? Password { get; set; }
}