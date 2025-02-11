namespace ScientificBit.Shopify.Models;

public class ShopifyOrderLineItem : ShopifyBaseModel
{
    public string? ProductId => Product?.Id;

    public string? VariantId => Variant?.Id;

    public int? CurrentQuantity { get; set; }

    public string? Sku { get; set; }

    public string? VariantImageUrl => Variant?.Image?.Url;

    public string? Name { get; set; } = string.Empty;

    public string? Title { get; set; } = string.Empty;

    public string? TitleAr => Product?.Translations?.FirstOrDefault(t => t.Locale == "ar")?.Value ?? Title;

    public string? VariantTitle { get; set; } = string.Empty;

    public string? VariantTitleAr => Variant?.Translations?.FirstOrDefault(t => t.Locale == "ar")?.Value ?? VariantTitle;

    public double Price => OriginalUnitPriceSet?.Value ?? 0;

    public ShopifyPriceSet? OriginalUnitPriceSet { get; set; }

    public ShopifyPriceSet? DiscountedTotalSet { get; set; }

    public ShopifyPriceSet? DiscountedUnitPriceAfterAllDiscountsSet { get; set; }

    public ShopifyPriceSet? DiscountedUnitPriceSet { get; set; }

    public ShopifyImage? Image { get; set; }

    public int? Quantity { get; set; }

    public int? UnfulfilledQuantity { get;set; }

    public int? RefundableQuantity { get; set; }

    public IList<ShopifyCustomAttribute>? CustomAttributes { get; set; }

    public string FulfillmentStatus => UnfulfilledQuantity > 0
        ? Enums.FulfillmentStatus.Unfulfilled.ToString().ToLower()
        : Enums.FulfillmentStatus.Fulfilled.ToString().ToLower();

    public int? NonFulfillableQuantity { get; set; }

    public int? FulfillableQuantity => Quantity - NonFulfillableQuantity;

    public bool? RequiresShipping { get; set; }

    public bool? IsGiftCard { get; set; }

    public bool? Restockable { get; set; }

    public double TotalDiscount => TotalDiscountSet?.Value ?? 0;

    public ShopifyPriceSet? TotalDiscountSet { get; set; }

    public ShopifyPriceSet? UnfulfilledDiscountedTotalSet { get; set; }

    public ShopifyPriceSet? UnfulfilledOriginalTotalSet { get; set; }

    public IList<ShopifyDiscountAllocation>? DiscountAllocations { get; set; }

    public ShopifyPriceSet? OriginalTotalSet { get; set; }

    public string? Vendor { get; set; }

    public bool ProductExists => Product != null;

    public string? Barcode => Variant?.Barcode;

    public ShopifyProduct<ShopifyBaseModel>? Product { get; set; }

    public ShopifyVariant? Variant { get; set; }
}