namespace ScientificBit.Shopify.Models;

public class ShopifyShippingLineItem : ShopifyBaseModel
{
    public string? Title { get; set; }

    public string? CarrierIdentifier { get; set; }

    public string? Code { get; set; }

    public string? DeliveryCategory { get; set; }

    public string? ShippingRateHandle { get; set; }

    public string? Source { get; set; }

    public bool? IsRemoved { get; set; }

    public bool? Custom { get; set; }

    public double Price => CurrentDiscountedPriceSet?.Value ?? DiscountedPriceSet?.Value ?? 0;

    public ShopifyPriceSet? CurrentDiscountedPriceSet { get; set; }

    public ShopifyPriceSet? DiscountedPriceSet { get; set; }

    public ShopifyPriceSet? OriginalPriceSet { get; set; }

    public IList<ShopifyDiscountAllocation>? DiscountAllocations { get; set; }
}