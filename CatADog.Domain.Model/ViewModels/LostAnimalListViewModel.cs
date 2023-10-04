using System;

namespace CatADog.Domain.Model.ViewModels;

public class LostAnimalListViewModel : IViewModel
{
    public long Id { get; set; }

    public DateOnly Date { get; set; }

    public bool Found { get; set; }

    public bool Approved { get; set; }

    public long AnimalId { get; set; }

    public long AddressId { get; set; }
}