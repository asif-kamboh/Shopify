using Microsoft.Extensions.Configuration;

namespace ScientificBit.Shopify.Configuration;

public class ShopifyConfigOptions
{
    private readonly IList<SalesChannelSecrets> _salesChannelTokens = new List<SalesChannelSecrets>();

    public IConfigurationSection? Configuration { get; set; }

    public string MultipassSecret { get; set; } = string.Empty;

    public string StoreDomain { get; set; } = string.Empty;

    public ShopifyConfigOptions AddDefaultSalesChannelTokens(string adminApiToken, string storefrontApiToken,
        string webhookApiSecret)
    {
        return AddSalesChannelTokens(string.Empty, adminApiToken, storefrontApiToken, webhookApiSecret);
    }

    public ShopifyConfigOptions AddSalesChannelTokens(string salesChannelId, string adminApiToken,
        string storefrontApiToken, string webhookApiSecret)
    {
        _salesChannelTokens.Add(new SalesChannelSecrets(salesChannelId)
        {
            AdminApiToken = adminApiToken,
            StorefrontApiToken = storefrontApiToken,
            WebhookApiSecret = webhookApiSecret
        });
        return this;
    }

    public ShopifyConfigOptions AddSalesChannelTokens(string salesChannelId, string clientId, string clientSecret,
        string storefrontApiToken, string webhookApiSecret)
    {
        _salesChannelTokens.Add(new SalesChannelSecrets(salesChannelId)
        {
            ClientId = clientId,
            ClientSecret = clientSecret,
            StorefrontApiToken = storefrontApiToken,
            WebhookApiSecret = webhookApiSecret
        });
        return this;
    }

    public SalesChannelSecrets[] SalesChannelTokens => _salesChannelTokens.ToArray();
}

public class SalesChannelSecrets
{
    internal SalesChannelSecrets(string salesChannelId)
    {
        SalesChannelId = salesChannelId;
    }

    internal string? SalesChannelId { get; }

    /// <summary>
    /// New Auth mechansim for Shopify Admin APIs
    /// </summary>
    internal string? ClientId { get; set; }

    /// <summary>
    /// New Auth mechansim for Shopify Admin APIs
    /// </summary>
    internal string? ClientSecret { get; set; }

    internal string? AdminApiToken { get; set; }

    internal string? StorefrontApiToken { get; set; }

    internal string? WebhookApiSecret { get; set; }
}