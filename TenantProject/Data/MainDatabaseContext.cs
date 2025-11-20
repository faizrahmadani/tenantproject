using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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
    }
}
