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
        Map(x => x.Description).Length(500).Not.Nullable();
        Map(x => x.PictureBase64).Length(5000).Nullable(); // Add LazyLoad?
    }
}