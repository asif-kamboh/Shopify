using Service.Shopify.Utils;

namespace Service.Shopify.Requests.GraphQl;

public interface IGraphQlQueryArgs
{
}

public abstract class GraphQlQueryArgs : IGraphQlQueryArgs
{
    /// <summary>
    /// Build string formatted args. Derived classes must implement it for more args
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerable<string> BuildArgs()
    {
        var props = GetType().GetProperties();

        return props.Select(p =>
        {
            var pVal = p.GetValue(this);
            if (pVal is null) return null;

            var key = p.Name.Length > 1
                ? $"{p.Name[..1].ToLower()}{p.Name[1..]}"
                : p.Name.ToLower();

            var val = GetStrValue(p.PropertyType, pVal);
            if (string.IsNullOrEmpty(val)) return null;
            var kv = $"{key}: {val}";
            return kv;
        }).Where(a => !string.IsNullOrEmpty(a))!;
    }

    private static string? GetStrValue(Type type, object? val)
    {
        if (TypeUtils.IsNumeric(type)) return val?.ToString();
        if (val is bool) return val.ToString()?.ToLower();
        return $"\"{val}\"";
    }

    /// <summary>
    /// Return formatted string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var args = BuildArgs();

        return string.Join(", ", args);
    }
}