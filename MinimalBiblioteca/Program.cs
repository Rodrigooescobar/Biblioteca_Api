using Microsoft.EntityFrameworkCore;
using MinimalBiblioteca.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodosDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TodosConnectionString")));

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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/todos", async (TodosDbContext db) => await db.Todos.ToListAsync()).WithOpenApi();

app.MapGet("/todos/{id}", async (int id, TodosDbContext db) =>
    await db.Todos.FindAsync(id) is Todo todo ? Results.Ok(todo) : Results.NotFound()
    );

app.MapPost("/todos", async (Todo todo, TodosDbContext db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
});

app.MapPut("/todos/{id}", async (int id, Todo todoInput, TodosDbContext db) =>
{
    var todo = await db.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    if (todo is null) return Results.NotFound();
    db.Entry(todoInput).State = EntityState.Modified;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/todos/{id}", async (int id, TodosDbContext db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null)
    {
        return Results.NotFound();
    }
    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
