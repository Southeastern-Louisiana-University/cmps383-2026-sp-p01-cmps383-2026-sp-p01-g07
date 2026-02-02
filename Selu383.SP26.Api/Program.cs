using Microsoft.EntityFrameworkCore;
using Selu383.SP26.Api.Data;
using Selu383.SP26.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Task 3: Apply migrations and seed data on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();

    // Automatically apply migrations to the database
    db.Database.Migrate();

    // Seed at least 3 Location records if the table is empty
    if (!db.Locations.Any())
    {
        db.Locations.AddRange(
            new Location { Name = "Southeastern University", Address = "123 Lion Ln", TableCount = 10 },
            new Location { Name = "Hammond Square", Address = "456 Mall Dr", TableCount = 5 },
            new Location { Name = "North Oaks", Address = "789 Medical Ctr", TableCount = 20 }
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

// Required for integration tests
public partial class Program { }