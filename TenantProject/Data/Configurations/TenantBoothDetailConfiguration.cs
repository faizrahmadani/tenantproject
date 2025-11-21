using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantProject.Model.Entity;

namespace TenantProject.Data.Configurations;

public class TenantBoothDetailConfiguration : IEntityTypeConfiguration<TenantBoothDetail>
{
    public void Configure(EntityTypeBuilder<TenantBoothDetail> builder)
    {
        builder.ToTable("tenant_booth_detail");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("id");
        builder.Property(t => t.TenantId).HasColumnName("tenant_id");
        builder.Property(t => t.BoothNum).HasColumnName("booth_num");
    }
}
