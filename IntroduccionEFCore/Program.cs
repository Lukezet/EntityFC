using ServicaDB;
using Microsoft.EntityFrameworkCore;
using ServicaDB.Entidades;
using System.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Add services to the container.

builder.Services.AddControllers()
       .AddJsonOptions(opciones => opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
app.UseCors("AllowVueApp");//permite una VueApp
app.UseAuthorization();

app.MapControllers();

app.Run();
