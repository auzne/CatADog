using System;
using System.IO;
using CatADog.Infra.Mapping.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace CatADog.Infra.Repositories.NHibernate;

public class NHibernateHelper
{
    private static ISessionFactory? _sessionFactory;

    private static ISessionFactory CreateSessionFactory(bool createSchema = true)
    {
        if (_sessionFactory != null) return _sessionFactory;

        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

        var connectionString = GetConnectionString(env);
        if (connectionString == null)
            throw new ArgumentException("Missing ConnectionString::SqlServer");

        var databaseConfiguration = MsSqlConfiguration
            .MsSql2012.ConnectionString(connectionString);

        if (env.Trim().ToLower() == "development")
            databaseConfiguration.ShowSql();

        var configuration = Fluently.Configure()
            .Database(databaseConfiguration)
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AnimalMap>());

        if (createSchema)
            configuration.ExposeConfiguration(config => new SchemaExport(config).Create(false, true));

        _sessionFactory = configuration.BuildSessionFactory();

        return _sessionFactory;
    }

    public static ISession OpenSession()
    {
        return CreateSessionFactory().OpenSession();
    }

    public static string? GetConnectionString(string env)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json", true)
            .Build();

        return configuration.GetConnectionString("SqlServer");
    }
}