using CatADog.Domain.Repositories;
using CatADog.Domain.Services;
using CatADog.Domain.Validation;
using CatADog.Infra.Repositories.NHibernate;
using CatADog.Infra.Starter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

#region Cors

var corsBuilder = new CorsPolicyBuilder()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();

builder.Services.AddCors(options => options.AddPolicy("AllowAll", corsBuilder.Build()));

#endregion

builder.Services.AddControllers();

#region Services

builder.Services.AddScoped(typeof(Validator<>));
builder.Services.AddSingleton(AutoMapperHelper.GetMapper());
builder.Services.AddScoped(typeof(QueryService<>));
builder.Services.AddScoped(typeof(CrudService<>));

// register services in CatADog.Domain.Services project
builder.Services.Scan(scan => scan
    .FromAssemblyOf<AnimalService>()
    .AddClasses()
    .AsSelf()
    .WithScopedLifetime());

#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvcCore()
    .AddNewtonsoftJson(x =>
        x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "CatADog API V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();