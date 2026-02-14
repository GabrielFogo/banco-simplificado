using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;

namespace BancoSimplificado.Api.Configs;

public static class SwaggerConfig
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme.",
                In = ParameterLocation.Header,
            });

            options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference(JwtBearerDefaults.AuthenticationScheme, document)] = []
            });
        });

        return services;
    }
}
