using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public class ShopifyOrderRefundInfo : ShopifyBaseModel
{
    public string? Note { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public GraphQlConnection<ShopifyRefundLineItem>? RefundLineItems { get; set; }

    public GraphQlConnection<ShopifyRefundShippingLine>? RefundShippingLines { get; set; }
}