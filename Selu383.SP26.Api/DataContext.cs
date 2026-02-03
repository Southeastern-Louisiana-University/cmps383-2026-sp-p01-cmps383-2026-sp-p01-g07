using Microsoft.EntityFrameworkCore;

namespace Selu383.SP26.Api;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}
    
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>()
            .Property(l => l.name)
            .IsRequired()
            .HasMaxLength(120);

        modelBuilder.Entity<Loctaion>()
            .Property(l => l.Adress)
            .IsRequired();

        modelBuilder.Entity<Locations>()
            .Property(l => l.TableCount)
            .IsRequired();



    }








}



// Compare this snippet from Selu383.SP26.Api/DataContext.cs: