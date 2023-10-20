using CatADog.Domain.Model.ValueObjects;
using FluentNHibernate.Mapping;

namespace CatADog.Infra.Mapping.NHibernate;

public class DatesMap : ComponentMap<Dates>
{
    public DatesMap()
    {
        Map(x => x.Age).Nullable();
        Map(x => x.Dewormed).Not.Nullable();
        Map(x => x.Neutered).Not.Nullable();
        Map(x => x.Vaccinated).Not.Nullable();
        Map(x => x.Adoption).Nullable();
    }
}