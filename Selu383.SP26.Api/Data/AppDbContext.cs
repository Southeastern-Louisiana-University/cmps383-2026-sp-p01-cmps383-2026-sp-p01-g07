using Microsoft.EntityFrameworkCore;                // DbContext, DbSet
using Selu383.SP26.Api.Models;                      // Location entity

namespace Selu383.SP26.Api.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }                         // pass options to EF

    public DbSet<Location> Locations { get; set; } = default!; // table
}
