using Service.Shopify.Abstractions;
using Service.Shopify.Enums;

namespace Service.Shopify.Clients.Handlers;

public class AdminGraphQlApiMessageHandler : HttpClientHandler
{
    private readonly IShopifyApiTokensAccessor _tokensAccessor;

    public AdminGraphQlApiMessageHandler(IShopifyApiTokensAccessor tokensAccessor)
    {
        _tokensAccessor = tokensAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var accessToken = _tokensAccessor.AdminApiToken;

        request.Headers.Add(ShopifyAuthHeaders.AdminApiAccessToken, accessToken);

        // Proceed with the request
        return await base.SendAsync(request, cancellationToken);
    }
}