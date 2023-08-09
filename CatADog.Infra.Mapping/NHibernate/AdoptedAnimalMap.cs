using CatADog.Domain.Model.Entities;
using FluentNHibernate.Mapping;

namespace CatADog.Infra.Mapping.NHibernate;

public class AdoptedAnimalMap : ClassMap<AdoptedAnimal>
{
    public AdoptedAnimalMap()
    {
        // primary key
        Id(x => x.Id).GeneratedBy.Native();
        
        // fields
        Map(x => x.Date).Not.Nullable();
        Map(x => x.Visited).Not.Nullable();

        // foreign keys
        References(x => x.Animal)
            .Column("AnimalId")
            .Fetch.Join()
            .Not.LazyLoad()
            .Not.Nullable();
        
        References(x => x.Adopter)
            .Column("AdopterId")
            .Fetch.Join()
            .Not.LazyLoad()
            .Not.Nullable();
    }
}