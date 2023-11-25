using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.Dtos;

public class ChangePasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [PasswordPropertyText]
    public string Password { get; set; }

    [Required]
    [PasswordPropertyText]
    public string NewPassword { get; set; }
}