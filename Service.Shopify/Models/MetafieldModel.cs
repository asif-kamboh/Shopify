using Newtonsoft.Json;
using Service.Shopify.Enums;
using Service.Shopify.Utils;

namespace Service.Shopify.Models;

public abstract class MetafieldBaseModel
{
    public string Namespace { get; set; } = "global";

    public string? Key { get; set; }

    public string? Value { get; set; }

    public string? Description { get; set; }

    public long OwnerId { get; set; }

    public string? OwnerResource { get; set; }

    public string Type { get; set; } = "string";

    public string? AdminGraphqlApiId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public object? GetValue()
    {
        return MetafieldTypes.SingleLineText.Equals(Type, StringComparison.InvariantCultureIgnoreCase) ||
               MetafieldTypes.MultiLineText.Equals(Type, StringComparison.InvariantCultureIgnoreCase)
            ? Value
            : JsonConvert.DeserializeObject(Value ?? string.Empty);
    }

    public T? GetValue<T>()
    {
        return JsonConvert.DeserializeObject<T>(Value ?? string.Empty);
    }
}

public class MetafieldModel : MetafieldBaseModel, IShopifyBaseModel
{
    public string? Id { get; set; }

    public long? GetNumericId() => ShopifyUtils.GetNumericId(Id);
}

public class MetafieldAdminModel : MetafieldBaseModel
{
    public long Id { get; set; }
}