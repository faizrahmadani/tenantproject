using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantProject.Model.Entity;

namespace TenantProject.Data.Configurations;

public class TenantSpaceDetailConfiguration : IEntityTypeConfiguration<TenantSpaceDetail>
{
    public void Configure(EntityTypeBuilder<TenantSpaceDetail> builder)
    {
        builder.ToTable("tenant_space_detail");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("id");
        builder.Property(t => t.TenantId).HasColumnName("tenant_id");
        builder.Property(t => t.AreaSm).HasColumnName("area_sm");
    }
}
