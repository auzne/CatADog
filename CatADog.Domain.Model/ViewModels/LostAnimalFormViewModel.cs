using System;

namespace CatADog.Domain.Model.ViewModels;

public class LostAnimalFormViewModel : IViewModel
{
    public long Id { get; set; }

    public DateTime Date { get; set; }

    public bool Found { get; set; }

    public bool Approved { get; set; }

    public long AnimalId { get; set; }

    public long AddressId { get; set; }
}