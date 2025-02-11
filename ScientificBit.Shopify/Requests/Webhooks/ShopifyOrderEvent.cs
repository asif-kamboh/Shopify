namespace ScientificBit.Shopify.Requests.Webhooks;

/// <summary>
/// A minimal definition for order payload from a Shopify webhook
/// When handling order events, it is recommended to fetch the Order
/// via Shopify GraphQL Admin API
/// </summary>
public class ShopifyOrderEvent
{
    /// <summary>
    /// Order ID 
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// GraphQL ID for order
    /// </summary>
    public string AdminGraphqlApiId { get; set; } = string.Empty;
    /// <summary>
    /// Order display name
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// When the order was cancelled
    /// </summary>
    public DateTime? CancelledAt { get; set; }
}