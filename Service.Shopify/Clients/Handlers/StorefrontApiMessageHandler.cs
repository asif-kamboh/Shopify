using Service.Shopify.Abstractions;
using Service.Shopify.Enums;

namespace Service.Shopify.Clients.Handlers;

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
        var accessToken = _tokensAccessor.StorefrontApiToken;

        request.Headers.Add(ShopifyAuthHeaders.StorefrontAccessToken, accessToken);

        // Proceed with the request
        return await base.SendAsync(request, cancellationToken);
    }
}