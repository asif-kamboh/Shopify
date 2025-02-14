using ScientificBit.Shopify.Abstractions;
using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Configuration;
using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Clients.GraphQl;

internal class AdminApiClient : ShopifyGraphApiClient, IAdminApiClient
{
    public AdminApiClient(ShopifyConfig config, IShopifyApiTokensAccessor tokensAccessor)
        : base(config.AdminGraphQlApiUrl, ShopifyAuthHeaders.AdminApiAccessToken, tokensAccessor.AdminApiToken)
    {
    }
}