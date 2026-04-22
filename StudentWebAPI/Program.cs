using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// EF Core - SQLite, Code First
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=studentapi.db"));

// NSwag - OpenAPI document + Swagger UI
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Student WebAPI";
    config.Version = "v1";
    config.Description = "ASP.NET Core WebAPI with four controllers: Students, Hobbies, BreakfastFoods, Movies.";
});

var app = builder.Build();

// Apply EF migrations / create DB on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

// NSwag middleware
app.UseOpenApi();       // serves /swagger/v1/swagger.json
app.UseSwaggerUi();     // serves /swagger UI

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
