namespace Service.Shopify.Models;

public class ShopifyRefundShippingLine : ShopifyBaseModel
{
    public ShopifyBaseModel? ShippingLine { get; set; }

    public double SubtotalAmount => SubtotalAmountSet?.Value ?? 0;

    public double TaxAmount => TaxAmountSet?.Value ?? 0;

    public ShopifyPriceSet? SubtotalAmountSet { get; set; }

    public ShopifyPriceSet? TaxAmountSet { get; set; }
}