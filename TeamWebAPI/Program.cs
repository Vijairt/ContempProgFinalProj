using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Entity Framework Core - Code First with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// NSwag - OpenAPI/Swagger
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Team WebAPI";
    config.Version = "v1";
    config.Description = "ASP.NET Core WebAPI with four controllers: TeamMembers, Hobbies, BreakfastFoods, Movies.";
});

var app = builder.Build();

// Auto-apply migrations and seed data on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// NSwag middleware
app.UseOpenApi();
app.UseSwaggerUi();

app.UseAuthorization();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
