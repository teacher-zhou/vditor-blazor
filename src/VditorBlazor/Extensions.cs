using System.ComponentModel;
using System.Reflection;

namespace VditorBlazor;

internal static class Extensions
{
    public static string? GetDefaultValueAsString(this Enum @enum)
    {
        var enumType = @enum.GetType();

        var defaultValueAttr = enumType.GetField(@enum.ToString()).GetCustomAttribute<DefaultValueAttribute>();
        return defaultValueAttr?.Value?.ToString() ?? @enum.ToString()?.ToLowerInvariant();
    }
}
