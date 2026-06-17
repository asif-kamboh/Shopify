using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public class DraftOrderModel : ShopifyBaseModel
{
    public string Name { get; set; } = string.Empty;

    public string? Status { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public IList<string>? Tags { get; set; }

    public string? CurrencyCode { get; set; }

    public string? InvoiceUrl { get; set; }

    public bool? TaxExempt { get; set; }

    public bool? TaxesIncluded { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime? InvoiceSentAt { get; set; }

    public double SubtotalPrice => SubtotalPriceSet?.Value ?? 0;

    public double TotalPrice => TotalPriceSet?.Value ?? 0;

    public double TotalTax => TotalTaxSet?.Value ?? 0;

    public double TotalShippingPrice => TotalShippingPriceSet?.Value ?? 0;

    public ShopifyPriceSet? SubtotalPriceSet { get; set; }

    public ShopifyPriceSet? TotalPriceSet { get; set; }

    public ShopifyPriceSet? TotalTaxSet { get; set; }

    public ShopifyPriceSet? TotalShippingPriceSet { get; set; }

    public ShopifyCustomerInfo? Customer { get; set; }

    public ShopifyCustomerAddress? BillingAddress { get; set; }

    public ShopifyCustomerAddress? ShippingAddress { get; set; }

    public GraphQlConnection<DraftOrderLineItem>? LineItems { get; set; }

    public OrderInfo? Order { get; set; }

    public class OrderInfo : ShopifyBaseModel
    {
        public string Name { get; set; } = string.Empty;
    }

    public class DraftOrderLineItem : ShopifyBaseModel
    {
        public string? Name { get; set; }

        public string? Title { get; set; }

        public string? Sku { get; set; }

        public int? Quantity { get; set; }

        public bool? RequiresShipping { get; set; }

        public string? Vendor { get; set; }

        public double OriginalUnitPrice => OriginalUnitPriceSet?.Value ?? 0;

        public ShopifyPriceSet? OriginalUnitPriceSet { get; set; }

        public ShopifyPriceSet? DiscountedTotalSet { get; set; }
    }
}