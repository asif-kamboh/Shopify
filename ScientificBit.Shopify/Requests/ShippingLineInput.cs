using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Requests;

public class ShippingLineInput
{
    public ShopifyMoneyV2? PriceWithCurrency { get; set; }

    public string? Title { get; set; }

    public string? ShippingRateHandle { get; set; }
}