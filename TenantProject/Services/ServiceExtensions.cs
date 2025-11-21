namespace TenantProject.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<TenantService>();
        services.AddScoped<TokenService>();
        return services;
    }
}
