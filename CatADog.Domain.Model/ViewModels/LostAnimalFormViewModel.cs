using System;
using System.ComponentModel.DataAnnotations;

namespace CatADog.Domain.Model.ViewModels;

public class LostAnimalFormViewModel : IViewModel
{
    public long Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public bool Found { get; set; }

    [Required]
    public bool Approved { get; set; }

    [Required]
    public string Description { get; set; }

    public string? PictureBase64 { get; set; }
}