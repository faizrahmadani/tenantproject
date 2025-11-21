using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantProject.Model.Entity;

namespace TenantProject.Data.Configurations;

public class TenantTypeConfiguration : IEntityTypeConfiguration<TenantType>
{
    public void Configure(EntityTypeBuilder<TenantType> builder)
    {
        builder.ToTable("tenant_type");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("id");
        builder.Property(t => t.Name).HasColumnName("name");
    }
}
