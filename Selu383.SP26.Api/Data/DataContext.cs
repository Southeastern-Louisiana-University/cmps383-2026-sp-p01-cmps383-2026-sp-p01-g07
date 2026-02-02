using Microsoft.EntityFrameworkCore;

namespace Selu383.SP26.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var location = modelBuilder.Entity<Location>();
            location.Property(x => x.Name).IsRequired().HasMaxLength(120);
            location.Property(x => x.Address).IsRequired();
        }
    }
}