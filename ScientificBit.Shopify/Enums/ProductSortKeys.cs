using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Enums;

/// <summary>
/// This static class provides string constants representing valid sort keys for Shopify products.
/// These keys are used to specify sorting criteria when querying products via the Shopify API.
/// </summary>
public static class ProductSortKeys
{
    /// <summary>
    /// Sort by the title value.
    /// </summary>
    public static readonly ShopifySortKey Title = new("TITLE");

    /// <summary>
    /// Sort by the inventory_total value.
    /// </summary>
    public static readonly ShopifySortKey InventoryTotal = new("INVENTORY_TOTAL");

    /// <summary>
    /// Sort by the product_type value.
    /// </summary>
    public static readonly ShopifySortKey ProductType = new("PRODUCT_TYPE");

    /// <summary>
    /// Sort by the published_at value.
    /// </summary>
    public static readonly ShopifySortKey PublishedAt = new("PUBLISHED_AT");

    /// <summary>
    /// Sort by relevance to the search terms when the query parameter is specified on the connection. Don't use this sort key when no search query is specified.
    /// </summary>
    public static readonly ShopifySortKey Relevance = new("RELEVANCE");

    /// <summary>
    /// Sort by the created_at value.
    /// </summary>
    public static readonly ShopifySortKey CreatedAt = new("CREATED_AT");

    /// <summary>
    /// Sort by the updated_at value.
    /// </summary>
    public static readonly ShopifySortKey UpdatedAt = new("UPDATED_AT");

    /// <summary>
    /// Sort by the vendor value.
    /// </summary>
    public static readonly ShopifySortKey Vendor = new("VENDOR");
}