using CatADog.Domain.Model.Enums;
using CatADog.Domain.Model.ValueObjects;

namespace CatADog.Domain.Model.ViewModels;

public class AnimalFormViewModel : IViewModel
{
    public long Id { get; set; }

    public string? Microchip { get; set; }

    public string Species { get; set; }

    public string Race { get; set; }

    public string Color { get; set; }

    public Sex Sex { get; set; }

    public bool Ccz { get; set; }

    public Dates Dates { get; set; }

    public long AdopterId { get; set; }
}