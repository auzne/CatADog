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
        if (_sessionFactory != null)
            return _sessionFactory;

        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

        var sqliteFile = GetConnectionString(env, "SQLiteFile");
        if (sqliteFile == null)
            throw new ArgumentException("Missing ConnectionString::SQLiteFile");

        var databaseConfiguration = SQLiteConfiguration
            .Standard.UsingFile(sqliteFile);

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

    public static string? GetConnectionString(string env, string key)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json", true)
            .Build();

        return configuration.GetConnectionString(key);
    }
}