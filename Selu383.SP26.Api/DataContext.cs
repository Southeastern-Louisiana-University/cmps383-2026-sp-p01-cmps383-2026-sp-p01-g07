using Microsoft.EntityFrameworkCore;

namespace Selu383.SP26.Api;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}

// Compare this snippet from Selu383.SP26.Api/DataContext.cs: