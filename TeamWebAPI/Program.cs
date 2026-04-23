using Microsoft.EntityFrameworkCore;
using TeamWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Team Web API";
    config.Version = "v1";
    config.Description = "A Web API for managing team members, hobbies, breakfast foods, and favorite movies.";
    config.UseControllerSummaryAsTagDescription = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(settings =>
    {
        settings.DocumentTitle = "Team Web API";
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
