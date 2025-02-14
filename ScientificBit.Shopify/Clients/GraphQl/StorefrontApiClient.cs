using ScientificBit.Shopify.Abstractions;
using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Configuration;
using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Clients.GraphQl;

internal class StorefrontApiClient : ShopifyGraphApiClient, IStorefrontApiClient
{
    public StorefrontApiClient(ShopifyConfig config, IShopifyApiTokensAccessor tokensAccessor)
        : base(config.StorefrontApiUrl, ShopifyAuthHeaders.StorefrontAccessToken, tokensAccessor.StorefrontApiToken)
    {
    }
}