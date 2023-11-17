using System.ComponentModel.DataAnnotations;
using CatADog.Domain.Model.Enums;
using CatADog.Domain.Model.ValueObjects;

namespace CatADog.Domain.Model.ViewModels;

public class AnimalFormViewModel : IViewModel
{
    public long Id { get; set; }

    [StringLength(45, MinimumLength = 40)] public string? Microchip { get; set; }

    [Required]
    [StringLength(45, MinimumLength = 2)]
    public string Name { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Species { get; set; }

    [Required]
    [StringLength(45, MinimumLength = 3)]
    public string Race { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 2)]
    public string Color { get; set; }

    [Required] public Sex Sex { get; set; }

    [Required] public bool Ccz { get; set; }

    [Required] public Dates Dates { get; set; }

    public long AdopterId { get; set; }
}