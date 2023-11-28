using Api.Funcionalidades;
using Api.Persistencia;
using Carter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceManager();
builder.Services.AddCarter();

var connectionString = builder.Configuration.GetConnectionString("5to_TiendaOnline");

builder.Services.AddDbContext<TiendaOnlineDbContext>(opcion =>
    opcion.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33))));

var opciones = new DbContextOptionsBuilder<TiendaOnlineDbContext>();

opciones.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33)));

var contexto = new TiendaOnlineDbContext(opciones.Options);

contexto.Database.EnsureCreated();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
