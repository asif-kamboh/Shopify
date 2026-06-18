namespace ScientificBit.Shopify.Models;

public class ShopifyCatalog : ShopifyBaseModel
{
    public string? Status { get; set; }

    public ShopifyPriceList? PriceList { get; set; }
}
