using ScientificBit.Shopify.Abstractions;
using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Exceptions;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Requests.Storefront.Queries;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Domain;

internal class ShopifyMetaObjectService : IShopifyMetaObjectService
{
    private readonly IStorefrontApiClient _client;

    public ShopifyMetaObjectService(IStorefrontApiClient client)
    {
        _client = client;
    }

    #region Public methods

    public async Task<IList<MetaObjectModel>> GetAllAsync(string type)
    {
        var query = new MetaObjectsByTypeQuery(type);
        var result = await _client.RunQueryAsync<MetaObjectsApiResponse>(query);
        if (result.Errors != null)
        {
            var error = result.Errors.FirstOrDefault();
            throw new ShopifyApiException($"Failed to query: {error?.Message}");
        }

        return result.Data?.MetaObjects?.Nodes ?? new List<MetaObjectModel>();
    }

    public async Task<MetaObjectModel?> GetAsync(string gid)
    {
        var query = new MetaObjectByIdQuery(gid);
        var result = await _client.RunQueryAsync<MetaObjectApiResponse>(query);

        if (result.Errors != null)
        {
            var error = result.Errors.FirstOrDefault();
            throw new ShopifyApiException($"Failed to query: {error?.Message}");
        }

        return result.Data?.MetaObject;
    }

    #endregion
}