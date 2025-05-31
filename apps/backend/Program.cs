using backend.Features.CompanyFeature.Services;
using backend.MapProfiles;
using backend.Services;
using FluentValidation.AspNetCore;
using Kojh.DAL.Data;
using Kojh.DAL.Data.Interfaces;
using Kojh.DAL.Data.Repositories;
using Kojh.DAL.Seed;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Kojh API",
        Version = "v1",
        Description = "API documentation for Kojh project",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "your.email@example.com"
        }
    });

    //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.EnableAnnotations();
});

// Add DbConnection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Kojh.DAL")));
// Add UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Add Item Services
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICompanyServices, CompanyServices>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IAssociationRepository, AssociationRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ICompanyAssociationRepository, CompanyAssociationRepository>();
builder.Services.AddScoped<ICompanyLocationRepository, CompanyLocationRepository>();

// Add FluentValidation
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

// Mappers
builder.Services.AddSingleton<IMapper, Mapper>();
MappingConfig.RegisterMappings();


var app = builder.Build();

// SEED DATABASE HERE
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbDevSeeder.Seed(dbContext);
}

// Swagger only in dev
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kojh API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
