using Service.Shopify.Abstractions.Clients;
using Service.Shopify.Clients.Handlers;
using Service.Shopify.Configuration;

namespace Service.Shopify.Clients.GraphQl;

internal class StorefrontApiClient : ShopifyGraphApiClient, IStorefrontApiClient
{
    public StorefrontApiClient(ShopifyConfig config, StorefrontApiMessageHandler messageHandler)
        : base(config.StorefrontApiUrl, messageHandler)
    {
    }
}