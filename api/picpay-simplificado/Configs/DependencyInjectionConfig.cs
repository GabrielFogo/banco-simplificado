using picpay_simplificado.Interfaces;
using picpay_simplificado.Interfaces.Repositories;
using picpay_simplificado.Interfaces.Services;
using picpay_simplificado.Repositories;
using picpay_simplificado.Services;

namespace picpay_simplificado.Configs;

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
