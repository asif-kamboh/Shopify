using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Enums;

/// <summary>
/// Variants sorting keys
/// </summary>
public static class VariantSortKeys
{
    /// <summary>
    /// Sort by the id value. Default
    /// </summary>
    public static readonly ShopifySortKey Id = new("ID");

    /// <summary>
    /// Sort by the name value.
    /// </summary>
    public static readonly ShopifySortKey Name = new("NAME");

    /// <summary>
    /// Sort by the title value
    /// </summary>
    public static readonly ShopifySortKey Title = new("TITLE");

    /// <summary>
    /// Sort by the full_title value
    /// </summary>
    public static readonly ShopifySortKey FullTitle = new("FULL_TITLE");

    /// <summary>
    /// Sort by the sku value
    /// </summary>
    public static readonly ShopifySortKey Sku = new("SKU");

    /// <summary>
    /// Sort by relevance to the search terms when the `query` parameter is
    /// specified on the connection.
    /// Don't use this sort key when no search query is specified.
    /// </summary>
    public static readonly ShopifySortKey Relevance = new("RELEVANCE");

    /// <summary>
    /// Sort by available inventory quantity in the location specified by
    /// the query:"location_id:" argument.
    /// Don't use this sort key when no location_id in query is specified.
    /// </summary>
    public static readonly ShopifySortKey InventoryLevels = new("INVENTORY_LEVELS_AVAILABLE");

    /// <summary>
    /// Sort by the inventory_quantity value
    /// </summary>
    public static readonly ShopifySortKey InventoryQuantity = new("INVENTORY_QUANTITY");
}