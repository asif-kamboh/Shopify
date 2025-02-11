namespace ScientificBit.Shopify.Models;

public class ShopifyVariantSummary : MetafieldsSupportingModel
{
    public string Title { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;

    public string? Barcode { get; set; }

    public string DisplayName { get; set; } = string.Empty;

    public int InventoryQuantity { get; set; }

    public string AdminGraphqlApiId { get; set; } = string.Empty;

    public bool? AvailableForSale { get; set; }

    public bool? Taxable { get; set; }

    public decimal? Price { get; set; }

    public int? SellableOnlineQuantity { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; }
}