using ServicaDB;
using Microsoft.EntityFrameworkCore;
using ServicaDB.Entidades;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Añadimos los servicios de la clase dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(
    opciones => opciones.UseMySQL(connectionString));//configuramos la connection string en appsetting.json

builder.Services.AddAutoMapper(typeof(Program));//Configuramos el AUTOMAPPER

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
