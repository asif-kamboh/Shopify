using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class ShopifyProductSummary : ShopifyProductSummary<ShopifyVariantSummary>
{
}

public class ShopifyProductSummary<TVariant> : MetafieldsSupportingModel where TVariant : new()
{
    public string Title { get; set; } = string.Empty;

    public string Handle { get; set; } = string.Empty;

    public string Vendor { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string? BodyHtml { get; set; }

    public string? ProductType { get; set; }

    public string? TemplateSuffix { get; set; }

    public int? TotalInventory { get; set; }

    public IList<string>? Tags { get; set; }

    public GraphQlConnection<TVariant>? Variants { get; set; }

    public DateTime? PublishedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; }
}