using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantProject.Model.Entity;

namespace TenantProject.Data.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("tenant");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.TenantName)
            .HasColumnName("tenant_name");
        builder.Property(t => t.TenantTypeId)
            .HasColumnName("tenant_type_id");
        builder.Property(t => t.TenantAddress)
            .HasColumnName("tenant_address");
        builder.Property(t => t.TenantPhone)
            .HasColumnName("tenant_phone");

        builder.HasOne(t => t.TenantType)
            .WithOne(t => t.Tenant)
            .HasForeignKey<Tenant>(q => q.TenantTypeId);
    }
}
