using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.ViewModels;

public class AdopterFormViewModel : IViewModel
{
    public long Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string LastName { get; set; }

    [StringLength(30, MinimumLength = 3)] public string? Profession { get; set; }

    [Required]
    [StringLength(12, MinimumLength = 11)]
    public string CPF { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 9)]
    public string RG { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 8)]
    public string PhoneNumber { get; set; }

    [Required] public long AddressId { get; set; }
}