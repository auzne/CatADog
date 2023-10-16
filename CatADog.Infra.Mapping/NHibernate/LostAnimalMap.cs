using CatADog.Domain.Model.Entities;
using FluentNHibernate.Mapping;

namespace CatADog.Infra.Mapping.NHibernate;

public class LostAnimalMap : ClassMap<LostAnimal>
{
    public LostAnimalMap()
    {
        // primary key
        Id(x => x.Id).GeneratedBy.Native();

        // fields
        Map(x => x.Date).Not.Nullable();
        Map(x => x.Found).Not.Nullable();
        Map(x => x.Approved).Not.Nullable();

        // foreign keys
        References(x => x.Animal)
            .Column("AnimalId")
            .Fetch.Join()
            .Not.LazyLoad()
            .Not.Nullable();

        References(x => x.Address)
            .Column("AddressId")
            .Fetch.Join()
            .Not.LazyLoad()
            .Not.Nullable();
    }
}