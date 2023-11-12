using CatADog.Domain.Model.Entities;
using FluentNHibernate.Mapping;
using NHibernate.Type;

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
        Map(x => x.PictureUri).CustomType<UriType>().Nullable();
    }
}