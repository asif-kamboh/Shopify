namespace ScientificBit.Shopify.Enums;

/// <summary>
/// Product Status values
/// </summary>
public enum ProductStatus
{
    /// <summary>
    /// Product is draft
    /// </summary>
    Draft = 1,

    /// <summary>
    /// Product is active
    /// </summary>
    Active = 2,

    /// <summary>
    /// Product is archived
    /// </summary>
    Archived = 4,

    /// <summary>
    /// Product is unlisted
    /// </summary>
    Unlisted = 8,

    /// <summary>
    /// Product is marked deleted
    /// </summary>
    Deleted = 16
}