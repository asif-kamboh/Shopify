using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Clients.Handlers;
using ScientificBit.Shopify.Configuration;

namespace ScientificBit.Shopify.Clients.GraphQl;

internal class AdminApiClient : ShopifyGraphApiClient, IAdminApiClient
{
    public AdminApiClient(ShopifyConfig config, AdminGraphQlApiMessageHandler messageHandler)
        : base(config.AdminGraphQlApiUrl, messageHandler)
    {
    }
}