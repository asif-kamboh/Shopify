using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public class ShopifyProduct : ShopifyProduct<ShopifyVariantSummary>
{
}

/// <summary>
/// Missing fields:
/// combinedListing, combinedListingRole, compareAtPriceRange, contextualPricing,
/// featuredMedia, priceRangeV2, ...
/// </summary>
/// <typeparam name="TVariant"></typeparam>
public class ShopifyProduct<TVariant> : ShopifyProductSummary<TVariant> where TVariant : new()
{
    public GraphQlConnection<ShopifyProductBundleComponent>? BundleComponents { get; set; }

    public TaxonomyCategory? Category { get; set; }

    public GraphQlConnection<ShopifyCollection>? Collections { get; set; }

    public string? Description { get; set; }
 
    public string? DescriptionHtml { get; set; }

    public string? DefaultCursor { get; set; }

    public bool? IsGiftCard { get; set; }

    public bool? HasOnlyDefaultVariant { get; set; }

    public bool? HasOutOfStockVariants { get; set; }
 
    public bool? HasVariantsThatRequiresComponents { get; set; }

    public GraphQlConnection<ShopifyMedia>? Media { get; set; }

    public ShopifyCountModel? MediaCount { get; set; }

    public string? OnlineStorePreviewUrl { get; set; }

    public string? OnlineStoreUrl { get; set; }

    public IList<ProductOption>? Options { get; set; }

    public bool? TracksInventory { get; set; }

    public IList<ShopifyTranslation>? Translations { get; set; }

    public ShopifyCountModel? VariantsCount { get; set; }
}