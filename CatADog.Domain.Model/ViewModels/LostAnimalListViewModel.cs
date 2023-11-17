using System;

namespace CatADog.Domain.Model.ViewModels;

public class LostAnimalListViewModel : IViewModel
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public bool Found { get; set; }

    public bool Approved { get; set; }

    public string Description { get; set; }

    public string? PictureBase64 { get; set; }
}