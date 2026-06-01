using ScientificBit.Shopify.Abstractions;
using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Configuration;
using ScientificBit.Shopify.Enums;

namespace ScientificBit.Shopify.Clients.GraphQl;

internal class StorefrontApiClient : ShopifyGraphApiClient, IStorefrontApiClient
{
    public StorefrontApiClient(ShopifyConfig config, StorefrontApiMessageHandler httpMessageHandler)
        : base(config.StorefrontApiUrl, httpMessageHandler)
    {
    }
}

internal class StorefrontApiMessageHandler : HttpClientHandler
{
    private readonly IShopifyApiTokensAccessor _tokensAccessor;

    public StorefrontApiMessageHandler(IShopifyApiTokensAccessor tokensAccessor)
    {
        _tokensAccessor = tokensAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Add(ShopifyAuthHeaders.StorefrontAccessToken, _tokensAccessor.StorefrontApiToken);

        // Proceed with the request
        return await base.SendAsync(request, cancellationToken);
    }
}