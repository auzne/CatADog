using CatADog.Domain.Model.Entities;
using CatADog.Domain.Model.Enums;
using FluentNHibernate.Mapping;

namespace CatADog.Infra.Mapping.NHibernate;

public class AnimalMap : ClassMap<Animal>
{
    public AnimalMap()
    {
        // primary key
        Id(x => x.Id).GeneratedBy.Native();

        // fields
        Map(x => x.Microchip).Length(45).Nullable();
        Map(x => x.Species).Length(45).Not.Nullable();
        Map(x => x.Race).Length(45).Not.Nullable();
        Map(x => x.Color).Length(45).Not.Nullable();
        Map(x => x.Sex).CustomType<Sex>().Not.Nullable();
        Map(x => x.Ccz).Not.Nullable();

        // components
        Component(x => x.Dates, m =>
        {
            m.Map(x => x.Age).Nullable();
            m.Map(x => x.Dewormed).Not.Nullable();
            m.Map(x => x.Neutered).Not.Nullable();
            m.Map(x => x.Vaccinated).Not.Nullable();
        });
    }
}