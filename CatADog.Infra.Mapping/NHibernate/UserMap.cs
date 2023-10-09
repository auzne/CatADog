using CatADog.Domain.Model.Entities;
using FluentNHibernate.Mapping;

namespace CatADog.Infra.Mapping.NHibernate;

public class UserMap : ClassMap<User>
{
    public UserMap()
    {
        // primary key
        Id(x => x.Id).GeneratedBy.Native();

        // fields
        Map(x => x.Name).Length(30).Not.Nullable();
        Map(x => x.Email).Length(100).Not.Nullable();
        Map(x => x.Password).Length(128).Not.Nullable();
    }
}