namespace CatADog.Domain.Model.ViewModels;

public class AnimalListViewModel : IViewModel
{
    public long Id { get; set; }

    public string? Microchip { get; set; }

    public string Name { get; set; }

    public string Species { get; set; }

    public string Race { get; set; }

    public long AdopterId { get; set; }
}