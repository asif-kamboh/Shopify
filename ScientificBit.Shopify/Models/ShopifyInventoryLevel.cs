namespace ScientificBit.Shopify.Models;

public class ShopifyInventoryLevel : ShopifyBaseModel
{
    public string? LocationId => Location?.Id;

    public ShopifyBaseModel? Location { get; set; }

    public ShopifyInventoryQuantityLevels? Quantities { get; set; }

    public DateTime? UpdatedAt { get; set; }
}