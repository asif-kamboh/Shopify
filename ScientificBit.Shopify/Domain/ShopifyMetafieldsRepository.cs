using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Abstractions.Repo;
using ScientificBit.Shopify.Mappers;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Requests.Admin.Mutations;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Domain;

internal class ShopifyMetafieldsRepository : ShopifyBaseRepository, IShopifyMetafieldsRepository
{
    private readonly IAdminApiClient _apiClient;

    public ShopifyMetafieldsRepository(IAdminApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<GraphQlResult<List<MetafieldModel>>> SetAsync(IList<MetafieldSetInput> metafields)
    {
        var mutation = new MetafieldsSetMutation
        {
            Variables = new { Metafields = metafields }
        };

        var response = await _apiClient.RunMutationAsync<ShopifyMutationResponse<List<MetafieldModel>>>(mutation);
        return GraphQlResultMapper.BuildResult(response, () =>
            GraphQlResultMapper.CreateResult(response.Data.Result?.Data, response.Data.Result?.UserErrors,
                response.Errors)
        );
    }

    public async Task<GraphQlResult<MetafieldIdentifier?>> DeleteAsync(string ownerId, string ns, string key)
    {
        var result = await DeleteAsync(new List<MetafieldIdentifier>
        {
            new() { Key = key, Namespace = ns, OwnerId = ownerId }
        });

        return new GraphQlResult<MetafieldIdentifier?>
        {
            Data = result.Data?.FirstOrDefault(),
            Error = result.Error,
            GraphQlErrors = result.GraphQlErrors
        };
    }

    public async Task<GraphQlResult<List<MetafieldIdentifier>>> DeleteAsync(IList<MetafieldIdentifier> metafields)
    {
        var mutation = new MetafieldsDeleteMutation
        {
            Variables = new { Metafields = metafields }
        };

        var response = await _apiClient.RunMutationAsync<ShopifyMutationResponse<List<MetafieldIdentifier>>>(mutation);

        return GraphQlResultMapper.BuildResult(response, () =>
            GraphQlResultMapper.CreateResult(response.Data.Result?.Data, response.Data.Result?.UserErrors,
                response.Errors)
        );
    }
}