using CatADog.Domain.Model.Entities;
using FluentNHibernate.Mapping;

namespace CatADog.Infra.Mapping.NHibernate;

public class ContactMap : ClassMap<Contact>
{
    public ContactMap()
    {
        // primary key
        Id(x => x.Id).GeneratedBy.Native();

        // fields
        Map(x => x.PhoneNumber).Not.Nullable();

        // foreign keys
        References(x => x.Adopter)
            .Column("AdopterId")
            .Fetch.Join()
            .Not.LazyLoad()
            .Not.Nullable();
    }
}