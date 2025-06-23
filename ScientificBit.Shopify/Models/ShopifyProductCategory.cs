namespace ScientificBit.Shopify.Models;

public class ShopifyProductCategory : ShopifyBaseModel
{
    public string? ParentId { get; set; }

    public string Name { get; set; } = string.Empty;
}