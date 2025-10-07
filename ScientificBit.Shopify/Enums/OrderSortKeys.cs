using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Enums;

/// <summary>
/// This static class provides string constants representing valid sort keys for Shopify orders.
/// These keys are used to specify sorting criteria when querying orders via the Shopify API.
/// </summary>
public static class OrderSortKeys
{
    /// <summary>
    /// Sort by the unique order ID.
    /// </summary>
    public static readonly ShopifySortKey Id = new("ID");

    /// <summary>
    /// Sort by the order creation timestamp.
    /// </summary>
    public static readonly ShopifySortKey CreatedAt = new("CREATED_AT");

    /// <summary>
    /// Sort by the order last updated timestamp.
    /// </summary>
    public static readonly ShopifySortKey UpdatedAt = new("UPDATED_AT");

    /// <summary>
    /// Sort by relevance (context-specific, e.g., search results).
    /// </summary>
    public static readonly ShopifySortKey Relevance = new("RELEVANCE");

    /// <summary>
    /// Sort by the total price of the order.
    /// </summary>
    public static readonly ShopifySortKey TotalPrice = new("TOTAL_PRICE");

    /// <summary>
    /// Sort by the total quantity of items in the order.
    /// </summary>
    public static readonly ShopifySortKey TotalItemsQuantity = new("TOTAL_ITEMS_QUANTITY");

    /// <summary>
    /// Sort by the order number.
    /// </summary>
    public static readonly ShopifySortKey OrderNumber = new("ORDER_NUMBER");

    /// <summary>
    /// Sort by the financial status of the order.
    /// </summary>
    public static readonly ShopifySortKey FinancialStatus = new("FINANCIAL_STATUS");

    /// <summary>
    /// Sort by the fulfillment status of the order.
    /// </summary>
    public static readonly ShopifySortKey FulfillmentStatus = new("FULFILLMENT_STATUS");

    /// <summary>
    /// Sort by the destination address of the order.
    /// </summary>
    public static readonly ShopifySortKey Destination = new("DESTINATION");

    /// <summary>
    /// Sort by the customer's name.
    /// </summary>
    public static readonly ShopifySortKey CustomerName = new("CUSTOMER_NAME");

    /// <summary>
    /// Sort by the purchase order number.
    /// </summary>
    public static readonly ShopifySortKey PoNumber = new("PO_NUMBER");

    /// <summary>
    /// Sort by the processed timestamp of the order.
    /// </summary>
    public static readonly ShopifySortKey ProcessedAt = new("PROCESSED_AT");
}