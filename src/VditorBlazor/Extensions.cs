using System.ComponentModel;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace VditorBlazor;

public static class Extensions
{
    public static string? GetDefaultValueAsString(this Enum @enum)
    {
        var enumType = @enum.GetType();

        var defaultValueAttr = enumType.GetField(@enum.ToString()).GetCustomAttribute<DefaultValueAttribute>();
        return defaultValueAttr?.Value?.ToString() ?? @enum.ToString()?.ToLowerInvariant();
    }

    public static IServiceCollection AddVditor(this IServiceCollection services, Action<VditorOptions>? configure = default)
    {
        services.Configure<VditorOptions>(options => configure?.Invoke(options));
        return services;
    }
}
