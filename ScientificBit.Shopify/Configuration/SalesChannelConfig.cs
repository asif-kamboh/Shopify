namespace ScientificBit.Shopify.Configuration;

public class SalesChannelConfig
{
    public string SalesChannelId { get; set; } = string.Empty;

    public string AdminApiToken { get; set; } = string.Empty;

    public string StorefrontApiToken { get; set; } = string.Empty;

    public string WebhookApiSecret { get; set; } = string.Empty;

    public string? DefaultMetafieldsNamespace { get; set; }

    public string? DefaultInventoryLocationId { get; set; }
}