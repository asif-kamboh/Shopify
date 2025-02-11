using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Clients.Handlers;
using ScientificBit.Shopify.Configuration;

namespace ScientificBit.Shopify.Clients.GraphQl;

internal class StorefrontApiClient : ShopifyGraphApiClient, IStorefrontApiClient
{
    public StorefrontApiClient(ShopifyConfig config, StorefrontApiMessageHandler messageHandler)
        : base(config.StorefrontApiUrl, messageHandler)
    {
    }
}