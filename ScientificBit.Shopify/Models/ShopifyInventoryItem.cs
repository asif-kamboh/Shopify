using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public class ShopifyInventoryItem : ShopifyBaseModel
{
    public string Sku { get; set; } = string.Empty;

    public bool RequiresShipping { get; set; }

    public ShopifyInventoryLevel? InventoryLevel { get; set; }

    public GraphQlConnection<ShopifyInventoryLevel>? InventoryLevels { get; set; }
}