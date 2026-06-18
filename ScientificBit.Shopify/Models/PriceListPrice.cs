namespace ScientificBit.Shopify.Models;

public class PriceListPrice
{
    public string? VariantId => Variant?.Id;

    public double? Amount => Price?.Amount;

    public ShopifyBaseModel? Variant { get; set; }

    public ShopifyMoneyV2? Price { get; set; }
}