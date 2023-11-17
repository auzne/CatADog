using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.ViewModels;

public class AddressFormViewModel : IViewModel
{
    public long Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Street { get; set; }

    public int? Number { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string District { get; set; }

    [Required]
    [StringLength(3, MinimumLength = 1)]
    public string State { get; set; }

    [Required]
    [StringLength(9, MinimumLength = 8)]
    public string ZIP { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string City { get; set; }
}