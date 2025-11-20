using Microsoft.EntityFrameworkCore;

namespace TenantProject.Data.Configurations;

public static class ModelBuilderExtension
{
    public static void ApplyCustomConfiguration(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TenantConfiguration());
    }
}
