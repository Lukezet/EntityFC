using IntroduccionEFCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//A�adimos los servicios de la clase dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(
    opciones => opciones.UseSqlServer("name=DefaultConnection"));//configuramos la connection string en appsetting.json

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
