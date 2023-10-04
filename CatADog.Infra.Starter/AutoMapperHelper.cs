using System.Linq;
using AutoMapper;
using CatADog.Infra.Starter.Profiles;

namespace CatADog.Infra.Starter;

public class AutoMapperHelper
{
    public static IMapper GetMapper()
    {
        var mce = new MapperConfigurationExpression();

        // Add profiles from assembly
        var profiles = typeof(AnimalProfile).Assembly.GetTypes()
            .Where(x => typeof(Profile).IsAssignableFrom(x));

        foreach (var profile in profiles)
            mce.AddProfile(profile);

        var mc = new MapperConfiguration(mce);
        mc.AssertConfigurationIsValid();

        return new Mapper(mc);
    }
}