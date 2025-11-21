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
        builder.Property(t => t.Id)
            .HasColumnName("id");
        builder.Property(t => t.TenantName)
            .HasColumnName("tenant_name");
        builder.Property(t => t.TenantTypeId)
            .HasColumnName("tenant_type_id");
        builder.Property(t => t.TenantAddress)
            .HasColumnName("tenant_address");
        builder.Property(t => t.TenantPhone)
            .HasColumnName("tenant_phone");

        builder.HasOne(t => t.TenantType)
            .WithMany(t => t.Tenants)
            .HasForeignKey(q => q.TenantTypeId);

        builder.HasOne(t => t.TenantBoothDetail)
            .WithOne(b => b.Tenant)
            .HasForeignKey<TenantBoothDetail>(b => b.TenantId);

        builder.HasOne(t => t.TenantSpaceDetail)
            .WithOne(s => s.Tenant)
            .HasForeignKey<TenantSpaceDetail>(s => s.TenantId);
    }
}
