namespace Service.Shopify.Enums;

/// <summary>
/// Variants sorting keys
/// </summary>
public static class VariantSortKeys
{
    /// <summary>
    /// Sort by the id value. Default
    /// </summary>
    public const string Id = "ID";

    /// <summary>
    /// Sort by the name value.
    /// </summary>
    public const string Name = "NAME";

    /// <summary>
    /// Sort by the title value
    /// </summary>
    public const string Title = "TITLE";

    /// <summary>
    /// Sort by the full_title value
    /// </summary>
    public const string FullTitle = "FULL_TITLE";

    /// <summary>
    /// Sort by the sku value
    /// </summary>
    public const string Sku = "SKU";

    /// <summary>
    /// Sort by relevance to the search terms when the `query` parameter is
    /// specified on the connection.
    /// Don't use this sort key when no search query is specified.
    /// </summary>
    public const string Relevance = "RELEVANCE";

    /// <summary>
    /// Sort by available inventory quantity in the location specified by
    /// the query:"location_id:" argument.
    /// Don't use this sort key when no location_id in query is specified.
    /// </summary>
    public const string InventoryLevels = "INVENTORY_LEVELS_AVAILABLE";

    /// <summary>
    /// Sort by the inventory_quantity value
    /// </summary>
    public const string InventoryQuantity = "INVENTORY_QUANTITY";
}