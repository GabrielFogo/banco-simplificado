using BancoSimplificado.Api.Filters;
using System.Text.Json.Serialization;

namespace BancoSimplificado.Api.Configs;

public static class MvcConfig
{
    public static IMvcBuilder AddCustomMvc(this IServiceCollection services)
    {
        return services.AddControllers(options =>
        {
            options.Filters.Add(typeof(ApiExecpetionFilter));
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
    }
}
