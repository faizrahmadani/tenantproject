using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TenantProject.Data.Configurations;
using TenantProject.Model.Entity;

namespace TenantProject.Data;

public class MainDatabaseContext: IdentityDbContext
{
    public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options): base(options)
    {
        
    }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantType> TenantTypes { get; set; }
    public DbSet<TenantBoothDetail> TenantBoothDetails { get; set; }
    public DbSet<TenantSpaceDetail> TenantSpaceDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyCustomConfiguration();

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToLower());
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLower());
            }
        }

        var tenantTypes = new List<TenantType>()
        {
            new TenantType()
            {
                Id = Guid.Parse("3b0b302a-72e9-4eae-856f-a6737756cb5b"),
                Name = "Food Truck",
            },
            new TenantType()
            {
                Id = Guid.Parse("8c815abe-4b51-4f86-80de-bff5cb6d5baa"),
                Name = "Booth",
            },
            new TenantType()
            {
                Id = Guid.Parse("cd285a19-b09d-4900-8ac8-154a95e9f69f"),
                Name = "Space Only",
            }
        };

        builder.Entity<TenantType>().HasData(tenantTypes);
    }
}
