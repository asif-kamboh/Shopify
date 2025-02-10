namespace Service.Shopify.Configuration;

public class ShopifyConfig
{
    public string ApiVersion { get; set; } = "2025-01";

    public string ShopifyBaseUrl { get; set; } = string.Empty;

    public string MultipassSecret { get; set; } = string.Empty;

    public string StoreDomain { get; set; } = string.Empty;

    public IList<SalesChannelConfig> SalesChannels { get; set; } = new List<SalesChannelConfig>();

    public string StorefrontApiUrl => $"{ShopifyBaseUrl}/api/{ApiVersion}/graphql.json";

    public string AdminGraphQlApiUrl => $"{ShopifyBaseUrl}/admin/api/{ApiVersion}/graphql.json";

    public string AdminRestApiUrl => $"{ShopifyBaseUrl}/admin/api/{ApiVersion}";

    // public string StorefrontApiToken => SalesChannels.FirstOrDefault()?.StorefrontApiToken ?? "";
    //
    // public string AdminApiToken => SalesChannels.FirstOrDefault()?.AdminApiToken ?? "";
    //
    // public string WebhookApiSecret => SalesChannels.FirstOrDefault()?.WebhookApiSecret ?? "";

    public string DefaultMetafieldsNamespace => SalesChannels.FirstOrDefault()?.DefaultMetafieldsNamespace ?? "Default";

    public string? DefaultInventoryLocationId => SalesChannels.FirstOrDefault()?.DefaultInventoryLocationId;

    public SalesChannelConfig? GetApiConfig(string? channelId)
    {
        return SalesChannels.FirstOrDefault(s => s.SalesChannelId == channelId);
    }
}