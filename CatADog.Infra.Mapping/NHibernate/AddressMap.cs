using CatADog.Domain.Model.Entities;
using FluentNHibernate.Mapping;

namespace CatADog.Infra.Mapping.NHibernate;

public class AddressMap : ClassMap<Address>
{
    public AddressMap()
    {
        // primary key
        Id(x => x.Id).GeneratedBy.Native();

        // fields
        Map(x => x.Street).Length(100).Not.Nullable();
        Map(x => x.Number).Nullable();
        Map(x => x.District).Length(50).Not.Nullable();
        Map(x => x.State).Length(3).Not.Nullable();
        Map(x => x.ZIP).Length(9).Not.Nullable();
        Map(x => x.City).Length(50).Not.Nullable();
    }
}