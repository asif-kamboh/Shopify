using Microsoft.Extensions.Configuration;

namespace ScientificBit.Shopify.Configuration;

internal class ShopifyConfigurationBuilder
{
    public ShopifyConfig Build(ShopifyConfigOptions opts)
    {
        var shopifyConfig = opts.Configuration?.Get<ShopifyConfig>() ?? new ShopifyConfig();
        shopifyConfig.MultipassSecret = opts.MultipassSecret;
        shopifyConfig.StoreDomain = opts.StoreDomain;

        foreach (var channel in shopifyConfig.SalesChannels)
        {
            var secrets = opts.SalesChannelTokens.FirstOrDefault(c => c.SalesChannelId == channel.SalesChannelId);
            if (secrets is null) continue;

            if (!string.IsNullOrEmpty(secrets.AdminApiToken)) channel.AdminApiToken = secrets.AdminApiToken;
            if (!string.IsNullOrEmpty(secrets.StorefrontApiToken)) channel.StorefrontApiToken = secrets.StorefrontApiToken;
            if (!string.IsNullOrEmpty(secrets.WebhookApiSecret)) channel.WebhookApiSecret = secrets.WebhookApiSecret;
        }

        return shopifyConfig;
    }
}