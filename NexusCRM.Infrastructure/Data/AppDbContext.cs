using Microsoft.EntityFrameworkCore;
using NexusCRM.Domain.Entities;

namespace NexusCRM.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } // Constructor to pass options to the base DbContext

    // DbSets for the entities in the application
    public DbSet<User> Users => Set<User>();
    public DbSet<Company> Companies => Set<Company>();

    // Override OnModelCreating to apply configurations and set up global query filters
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Auto-apply all entity configurations from this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Global soft delete filter - automatically excludes deleted records
        modelBuilder.Entity<User>()
            .HasQueryFilter(u => !u.IsDeleted);

        modelBuilder.Entity<Company>()
            .HasQueryFilter(c => !c.IsDeleted);
    }
}
