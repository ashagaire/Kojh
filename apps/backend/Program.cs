using backend.Services;
using Deraa.DAL.Data;
using Deraa.DAL.Data.Interfaces;
using Deraa.DAL.Data.Repositories;
using FluentValidation.AspNetCore;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using backend.MapProfiles;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Deraa.DAL")));

//Add Item Services
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();


// Add FluentValidation
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

// Mappers
builder.Services.AddSingleton<IMapper, Mapper>();
MappingConfig.RegisterMappings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
