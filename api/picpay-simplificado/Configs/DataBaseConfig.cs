using Microsoft.EntityFrameworkCore;
using picpay_simplificado.Context;

namespace picpay_simplificado.Configs;

public static class DatabaseConfig
{
    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }
}
