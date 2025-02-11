using Microsoft.Extensions.Logging;
using Service.Shopify.Abstractions;
using Service.Shopify.Abstractions.Clients;
using Service.Shopify.Exceptions;
using Service.Shopify.Models;
using Service.Shopify.Requests.Storefront.Queries;
using Service.Shopify.Views;

namespace Service.Shopify.Domain;

internal class ShopifyCartService : IShopifyCartService
{
    private readonly ILogger<ShopifyCartService> _logger;
    private readonly IStorefrontApiClient _apiClient;

    public ShopifyCartService(ILogger<ShopifyCartService> logger, IStorefrontApiClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public async Task<ShopifyCartModel?> GetAsync(string cartId, IEnumerable<string> metafieldKeys, string metafieldsNamespace)
    {
        var query = new CartByIdQuery(cartId, metafieldKeys, metafieldsNamespace);
        var response = await _apiClient.RunQueryAsync<ShopifyCartApiResponse>(query);
        if (response.Errors != null)
        {
            var error = response.Errors.FirstOrDefault();
            _logger.LogError("GetAsync: Failed for CartId={CartId}. Error={Message}", cartId, error?.Message);
            throw new ShopifyApiException($"Unable to get Cart. Error={error?.Message}");
        }

        return response.Data.Cart;
    }
}