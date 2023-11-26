using System;
using System.Text;
using CatADog.Domain.Model.Settings;
using CatADog.Domain.Repositories;
using CatADog.Domain.Services;
using CatADog.Domain.Validation;
using CatADog.Infra.Repositories.NHibernate;
using CatADog.Infra.Starter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>()
                  ?? throw new Exception("AppSettings is not defined in any appsettings.json");
builder.Services.AddSingleton(appSettings);

#region Cors

var corsBuilder = new CorsPolicyBuilder()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();

builder.Services.AddCors(options => options.AddPolicy("AllowAll", corsBuilder.Build()));

#endregion

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = appSettings.Issuer,
            ValidAudience = appSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.Unicode.GetBytes(appSettings.Key)),
            ClockSkew = TimeSpan.FromMinutes(5)
        };
    });

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

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();