using Microsoft.EntityFrameworkCore;            // UseSqlServer, Migrate()
using Selu383.SP26.Api.Data;                    // AppDbContext
using Selu383.SP26.Api.Models;                  // Location entity (for seeding)

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();              // Enables controller endpoints
builder.Services.AddEndpointsApiExplorer();     // Swagger support
builder.Services.AddSwaggerGen();               // Swagger support

// Get connection string (fail fast if missing so it's obvious what to fix)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "Missing connection string 'DefaultConnection'. Add it to Selu383.SP26.Api/appsettings.json.");
}

// Register EF Core DbContext using SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Apply migrations + seed data so tests have at least 3 locations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    if (!db.Locations.Any())
    {
        db.Locations.AddRange(
            new Location { Name = "Cafe A", Address = "1 Main St", TableCount = 5 },
            new Location { Name = "Cafe B", Address = "2 Main St", TableCount = 10 },
            new Location { Name = "Cafe C", Address = "3 Main St", TableCount = 3 }
        );

        db.SaveChanges();
    }
}

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

// see: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0
// Hi 383 - this is added so we can test our web project automatically
public partial class Program { }
