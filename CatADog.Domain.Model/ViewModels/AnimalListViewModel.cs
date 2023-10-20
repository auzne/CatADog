using CatADog.Domain.Model.Enums;

namespace CatADog.Domain.Model.ViewModels;

public class AnimalListViewModel : IViewModel
{
    public long Id { get; set; }

    public string? Microchip { get; set; }

    public string Name { get; set; }

    public string Species { get; set; }

    public string Race { get; set; }

    public virtual string Color { get; set; }

    public virtual Sex Sex { get; set; }

    public virtual bool Ccz { get; set; }

    public long AdopterId { get; set; }
}