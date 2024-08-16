using Biblioteca.Data;
using Biblioteca.Services;
using Biblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BibliotecaDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("BibliotecaConnectionString")));

builder.Services.AddTransient<IAutoresService, AutoresService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// inicializamos la db con datos si no contiene ninguno
app.CreateDbIfNotExists();

app.Run();
