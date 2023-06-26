using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NetworkOfAirports_EF.API.Validation.Airline;
using NetworkOfAirports_EF.API.Validation.Airport;
using NetworkOfAirports_EF.API.Validation.Flight;
using NetworkOfAirports_EF.API.Validation.FlightPassenger;
using NetworkOfAirports_EF.BLL.DTO;
using NetworkOfAirports_EF.BLL.Interfaces;
using NetworkOfAirports_EF.BLL.Services;
using NetworkOfAirports_EF.DAL.Data;
using NetworkOfAirports_EF.DAL.Entitites;
using NetworkOfAirports_EF.DAL.Expansion.GenerateData;
using NetworkOfAirports_EF.DAL.Expansion.Helpers;
using NetworkOfAirports_EF.DAL.Expansion.Interfaces;
using NetworkOfAirports_EF.DAL.Interfaces;
using NetworkOfAirports_EF.DAL.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddControllers()
    .AddFluentValidation();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Network of Airports",
        Version = "v1",
        Description = "API for performing operations with \"Network of Airports\"",
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    op => op.MigrationsAssembly("NetworkOfAirports_EF.API")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IValidator<AirlineUpdateDTO>, AirlineUpdateDTOValidator>();
builder.Services.AddTransient<IValidator<AirlineCreateDTO>, AirlineCreateDTOValidator>();
builder.Services.AddTransient<IValidator<AirportUpdateDTO>, AirportUpdateDTOValidator>();
builder.Services.AddTransient<IValidator<AirportCreateDTO>, AirportCreateDTOValidator>();
builder.Services.AddTransient<IValidator<FlightPassengerUpdateDTO>, FlightPassengerUpdateDTOValidator>();
builder.Services.AddTransient<IValidator<FlightPassengerCreateDTO>, FlightPassengerCreateDTOValidator>();
builder.Services.AddTransient<IValidator<FlightUpdateDTO>, FlightUpdateDTOValidator>();
builder.Services.AddTransient<IValidator<FlightCreateDTO>, FlightCreateDTOValidator>();

builder.Services.AddScoped<IAirlineService, AirlineService>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IFlightPassengerService, FlightPassengerService>();
builder.Services.AddScoped<IFlightService, FlightService>();

builder.Services.AddScoped<ISortHelper<Airline>, SortHelper<Airline>>();
builder.Services.AddScoped<ISortHelper<Airport>, SortHelper<Airport>>();
builder.Services.AddScoped<ISortHelper<FlightPassenger>, SortHelper<FlightPassenger>>();
builder.Services.AddScoped<ISortHelper<Flight>, SortHelper<Flight>>();

builder.Services.AddScoped<IAirlineRepository, AirlineRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IFlightPassengerRepository, FlightPassengerRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//DataGenerator.Generate();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.MapControllers();
app.Run();
