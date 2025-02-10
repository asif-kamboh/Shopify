using Service.Shopify.Abstractions.Clients;
using Service.Shopify.Clients.Handlers;
using Service.Shopify.Configuration;

namespace Service.Shopify.Clients.GraphQl;

internal class AdminApiClient : ShopifyGraphApiClient, IAdminApiClient
{
    public AdminApiClient(ShopifyConfig config, AdminGraphQlApiMessageHandler messageHandler)
        : base(config.AdminGraphQlApiUrl, messageHandler)
    {
    }
}