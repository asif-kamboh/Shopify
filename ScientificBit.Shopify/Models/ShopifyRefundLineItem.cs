namespace ScientificBit.Shopify.Models;

public class ShopifyRefundLineItem : ShopifyBaseModel
{
    public int Quantity { get; set; }

    public bool Restocked { get; set; }

    public string? RestockType { get; set; } // CANCEL, LEGACY_RESTOCK, NO_RESTOCK, RETURN

    public string? LineItemId => LineItem?.Id;

    public string? LocationId => Location?.Id;

    public double Price => PriceSet?.Value ?? 0;

    public double Subtotal => SubtotalSet?.Value ?? 0;

    public ShopifyBaseModel? LineItem { get; set; }

    public ShopifyBaseModel? Location { get; set; }

    public ShopifyPriceSet? PriceSet { get; set; }

    public ShopifyPriceSet? SubtotalSet { get; set; }
}