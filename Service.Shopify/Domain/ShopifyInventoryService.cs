using Service.Shopify.Abstractions;
using Service.Shopify.Abstractions.Clients;
using Service.Shopify.Exceptions;
using Service.Shopify.Models;
using Service.Shopify.Requests.Admin.Queries;
using Service.Shopify.Views;

namespace Service.Shopify.Domain;

internal class ShopifyInventoryService : IShopifyInventoryService
{
    private readonly IAdminApiClient _apiClient;

    public ShopifyInventoryService(IAdminApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<ShopifyInventoryItem?> GetInventoryItemAsync(long itemId)
    {
        var gid = $"gid://shopify/InventoryItem/{itemId}";
        return GetInventoryItemAsync(gid);
    }

    public async Task<ShopifyInventoryItem?> GetInventoryItemAsync(string itemId)
    {
        var query = new InventoryItemByIdQuery(itemId);
        var response = await _apiClient.RunQueryAsync<ShopifyInventoryItemApiResponse>(query);
        var error = response.Errors?.FirstOrDefault();
        if (response.Data is null && error != null)
        {
            throw new ShopifyApiException(error.Message);
        }
        return response.Data?.InventoryItem;
    }
}