using CatADog.Domain.Model.Entities;
using FluentNHibernate.Mapping;

namespace CatADog.Infra.Mapping.NHibernate;

public class AdopterMap : ClassMap<Adopter>
{
    public AdopterMap()
    {
        // primary key
        Id(x => x.Id).GeneratedBy.Native();
        
        // fields
        Map(x => x.FirstName).Length(50).Not.Nullable();
        Map(x => x.LastName).Length(50).Not.Nullable();
        Map(x => x.Profession).Length(30).Nullable();
        Map(x => x.CPF).Length(12).Not.Nullable();
        Map(x => x.RG).Length(8).Not.Nullable();
        
        // foreign keys
        References(x => x.Address)
            .Column("AddressId")
            .Fetch.Join()
            .Not.LazyLoad()
            .Not.Nullable();
    }
}