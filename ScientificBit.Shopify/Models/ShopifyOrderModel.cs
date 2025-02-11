using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public class ShopifyOrderModel : MetafieldsSupportingModel
{
    public string Name { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public long OrderNumber => long.Parse(Name.Substring(1));

    public  bool? BillingAddressMatchesShippingAddress { get; set; }

    public bool? RequiresShipping { get; set; }

    public bool? Restockable { get; set; }

    // public long? CheckoutId { get; set; }

    // public string CheckoutToken { get; set; } = string.Empty;

    public string? FinancialStatus => DisplayFinancialStatus?.ToLower() ?? "pending";

    public string? DisplayFinancialStatus { get; set; }

    public string? FulfillmentStatus => DisplayFulfillmentStatus?.ToLower();

    public int? CurrentSubtotalLineItemsQuantity { get; set; }

    public double? CurrentTotalWeight { get; set; }

    public string? ConfirmationNumber { get; set; }

    public bool? Confirmed { get; set; }

    public string? DisplayFulfillmentStatus { get; set; }

    public IList<string>? Tags { get; set; } // tags

    public string? Note { get; set; } // note

    public string? CancelReason { get; set; }

    public DateTime? CancelledAt { get; set; }

    public ShopifyOrderCancellation? Cancellation { get; set; }

    public string? CancellationNote => Cancellation?.StaffNote;

    public string? CustomerLocale { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public DateTime? ClosedAt { get; set; }

    public  bool? Closed { get; set; }

    public string? StatusPageUrl { get; set; }

    public IList<ShopifyCustomAttribute>? CustomAttributes { get; set; }

    // public string? Reference { get; set; }

    public bool? Test { get; set; }

    public  string? ClientIp { get; set; }

    // public string? Token { get; set; }

    public string? CurrencyCode { get; set; } = "";

    public double TotalDiscounts => TotalDiscountsSet?.Value ?? 0;

    public double TotalOutstanding => TotalOutstandingSet?.Value ?? 0;

    public double SubtotalPrice => SubtotalPriceSet?.Value ?? 0;

    public double TotalPrice => TotalPriceSet?.Value ?? 0;

    public double TotalTax => TotalTaxSet?.Value ?? 0;

    public double CurrentTotalTax => CurrentTotalTaxSet?.Value ?? 0;

    public double CurrentSubtotalPrice => CurrentSubtotalPriceSet?.Value ?? 0;

    public double CurrentTotalDiscounts => CurrentTotalDiscountsSet?.Value ?? 0;

    public double CurrentTotalPrice => CurrentTotalPriceSet?.Value ?? 0;

    public ShopifyPriceSet? TotalDiscountsSet { get; set; }

    public ShopifyPriceSet? TotalOutstandingSet { get; set; }

    public ShopifyPriceSet? SubtotalPriceSet { get; set; }

    public ShopifyPriceSet? TotalPriceSet { get; set; }

    public ShopifyPriceSet? TotalTaxSet { get; set; }

    public ShopifyPriceSet? CurrentTotalTaxSet { get; set; }

    public ShopifyPriceSet? CurrentSubtotalPriceSet { get; set; }

    public ShopifyPriceSet? CurrentShippingPriceSet { get; set; }

    public ShopifyPriceSet? CurrentCartDiscountAmountSet { get; set; }

    public ShopifyPriceSet? CurrentTotalDiscountsSet { get; set; }

    public ShopifyPriceSet? CurrentTotalPriceSet { get; set; }

    public double TotalWeight { get; set; }

    // public long? UserId { get; set; }

    public string Gateway => PaymentGatewayNames?.FirstOrDefault() ?? string.Empty;

    public IList<string>? PaymentGatewayNames { get; set; }

    public ShopifyCustomerInfo? Customer { get; set; }

    public IList<ShopifyOrderRefundInfo>? Refunds { get; set; }

    public  bool? Refundable {get; set; }

    public string? DiscountCode { get; set; }

    public IList<string>? DiscountCodes { get; set; }

    public GraphQlConnection<ShopifyDiscountApplication>? DiscountApplications { get; set; }

    public ShopifyCustomerAddress? BillingAddress { get; set; }

    public ShopifyCustomerAddress? ShippingAddress { get; set; }

    public GraphQlConnection<ShopifyOrderLineItem>? LineItems { get; set; }

    public ShopifyShippingLineItem? ShippingLine { get; set; }

    public GraphQlConnection<ShopifyShippingLineItem>? ShippingLines { get; set; }

    public IList<ShopifyOrderTransaction>? Transactions { get; set; }
}