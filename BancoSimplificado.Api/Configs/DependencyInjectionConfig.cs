using BancoSimplificado.Api.Interfaces.Repositories;
using BancoSimplificado.Api.Interfaces.Services;
using BancoSimplificado.Api.Repositories;
using BancoSimplificado.Api.Services;

namespace BancoSimplificado.Api.Configs;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddCustomDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ITransactionServices, TransactionServices>();
        services.AddScoped<IUserService, UserServices>();

        return services;
    }
}
