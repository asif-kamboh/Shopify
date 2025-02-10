using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class ShopifyInventoryItem : ShopifyBaseModel
{
    public string Sku { get; set; } = string.Empty;

    public bool RequiresShipping { get; set; }

    public ShopifyInventoryLevel? InventoryLevel { get; set; }

    public GraphQlConnection<ShopifyInventoryLevel>? InventoryLevels { get; set; }
}