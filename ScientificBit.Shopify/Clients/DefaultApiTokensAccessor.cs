using Microsoft.AspNetCore.Http;
using ScientificBit.Shopify.Abstractions;
using ScientificBit.Shopify.Configuration;
using ScientificBit.Shopify.Extensions;

namespace ScientificBit.Shopify.Clients;

internal class DefaultApiTokensAccessor : IShopifyApiTokensAccessor
{
    private readonly ShopifyConfig _config;
    private readonly IHttpContextAccessor _contextAccessor;

    public DefaultApiTokensAccessor(ShopifyConfig config, IHttpContextAccessor contextAccessor)
    {
        _config = config;
        _contextAccessor = contextAccessor;
    }

    public string StorefrontApiToken => GetSalesChannel().StorefrontApiToken;

    public string AdminApiToken => GetSalesChannel().AdminApiToken;

    public string WebhookApiSecret => GetSalesChannel().WebhookApiSecret;

    private SalesChannelConfig GetSalesChannel()
    {
        var salesChannelId = _contextAccessor.GetShopifyChannelId();
        return _config.SalesChannels.FirstOrDefault(c => c.SalesChannelId == salesChannelId)
               ?? _config.SalesChannels.FirstOrDefault()
               ?? new SalesChannelConfig();
    }
}