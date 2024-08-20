using System.Text.Json.Serialization;
using picpay_simplificado.Filters;

namespace picpay_simplificado.Configs;

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
