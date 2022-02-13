using ITF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITF.Infrastructure;

public class ItfDbContext : DbContext
{
    private const string DbSchema = "Itf";
    
    public DbSet<User> Users => Set<User>();

    public DbSet<DeveloperProfile> DeveloperProfiles => Set<DeveloperProfile>();
    public DbSet<DeveloperCategory> DeveloperCategories => Set<DeveloperCategory>();

    public DbSet<RecruiterProfile> RecruiterProfiles => Set<RecruiterProfile>();
    public DbSet<Position> Positions => Set<Position>();

    public ItfDbContext(DbContextOptions<ItfDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}