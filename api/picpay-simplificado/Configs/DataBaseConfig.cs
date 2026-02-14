using BancoSimplificado.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace BancoSimplificado.Api.Configs;

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
