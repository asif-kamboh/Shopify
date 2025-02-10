using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class ShopifyCollection : ShopifyCollection<ShopifyProductSummary>
{
}

public class ShopifyCollection<TProduct> : MetafieldsSupportingModel where TProduct : new()
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? DescriptionHtml { get; set; }

    public string? Handle { get; set; }

    public bool? HasProduct { get; set; }

    public GraphQlConnection<TProduct>? Products { get; set; }

    public ShopifyImage? Image { get; set; }

    public ShopifyCountModel? ProductsCount { get; set; }

    public bool? PublishedOnPublication { get; set; }

    /// <summary>
    /// Possible values:
    /// ALPHA_ASC, ALPHA_DESC, BEST_SELLING, CREATED, CREATED_DESC, MANUAL, PRICE_ASC, PRICE_DESC
    /// </summary>
    public string? SortOrder { get; set; }

    public string? TemplateSuffix { get; set; }

    public IList<ShopifyTranslation>? Translations { get; set; }

    public DateTime? UpdatedAt { get; set; }
}