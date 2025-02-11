using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Models;

public class ShopifyResourceModel : ShopifyBaseModel
{
    protected ShopifyResourceModel()
    {
    }

    public IList<MetafieldModel>? Metafields { get; set; }

    public MetafieldModel? GetMetafield(string? key, string ns = "default")
    {
        return !string.IsNullOrEmpty(key)
            ? Metafields?.FirstOrDefault(m => key.Equals(m.Key) && ns.Equals(m.Namespace))
            : null;
    }

    public TVal? GetMetafieldValue<TVal>(string? key, string ns = "default")
    {
        // TODO transform the return value based on metafield type
        var metafield = GetMetafield(key, ns);
        return metafield != null ? metafield.GetValue<TVal>() : default;
    }
}