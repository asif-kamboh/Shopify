using System.Xml;
using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Abstractions.Repo;
using ScientificBit.Shopify.Mappers;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Models.Base;
using ScientificBit.Shopify.Requests.Admin.Mutations;
using ScientificBit.Shopify.Requests.Admin.Queries;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Domain;

internal class ShopifyMarketCatalogsRepository : ShopifyBaseRepository, IShopifyMarketCatalogsRepository
{
    private readonly IAdminApiClient _apiClient;

    public ShopifyMarketCatalogsRepository(IAdminApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<GraphQlResult<ShopifyCatalog>> GetMarketCatalogAsync(string query)
    {
        var gqlQuery = new CatalogsQuery(query);
        var response = await _apiClient.RunQueryAsync<CatalogsApiResponse>(gqlQuery);

        return GraphQlResultMapper.BuildResult(response, () =>
            GraphQlResultMapper.CreateResult(
                response.Data?.Catalogs?.Nodes?.FirstOrDefault(),
                null,
                response.Errors)
        );
    }

    public async Task<GraphQlResult<PriceListPrice?>> GetVariantPriceAsync(string priceListId, string variantId)
    {
        var result = await GetVariantPricesAsync(priceListId, new List<string> { variantId });
        return new GraphQlResult<PriceListPrice?>
        {
            Data = result.Data.FirstOrDefault(),
            Error = result.Error,
            GraphQlErrors = result.GraphQlErrors
        };
    }

    public async Task<GraphQlResults<PriceListPrice>> GetVariantPricesAsync(string priceListId,
        IList<string> variantIds)
    {
        var query = new PriceListFixedPricesQuery(priceListId, variantIds);
        var response = await _apiClient.RunQueryAsync<PriceListApiResponse>(query);

        return GraphQlResultMapper.BuildResults<PriceListPrice>(response, () =>
            GraphQlResultMapper.CreateResult(
                response.Data?.PriceList?.Prices,
                null,
                response.Errors)
        );
    }

    public async Task<GraphQlResult<PriceListPrice?>> UpdateVariantPriceAsync(string priceListId, PriceListPriceInput prices)
    {
       // var resultX = await GetVariantPricesAsync(priceListId, new List<string> { prices.VariantId });
        var result = await UpdateVariantPricesAsync(priceListId, new List<PriceListPriceInput> { prices });
        return new GraphQlResult<PriceListPrice?>
        {
            Data = result.Data.FirstOrDefault(),
            Error = result.Error,
            GraphQlErrors = result.GraphQlErrors
        };
    }

    public async Task<GraphQlResults<PriceListPrice>> UpdateVariantPricesAsync(string priceListId,
        IList<PriceListPriceInput> prices)
    {
        var mutation = new PriceListFixedPricesAddMutation
        {
            Variables = new { PriceListId = priceListId, Prices = prices }
        };

        var response = await _apiClient.RunMutationAsync<ShopifyMutationResponse<List<PriceListPrice>>>(mutation);

        return GraphQlResultMapper.BuildResults<PriceListPrice>(response, () =>
            GraphQlResultMapper.CreateResult<PriceListPrice>(
                response.Data?.Result?.Data,
                response.Data?.Result?.UserErrors,
                response.Errors)
        );
    }
}

internal class CatalogsApiResponse
{
    public CatalogsConnection? Catalogs { get; set; }

    internal class CatalogsConnection
    {
        public IList<ShopifyCatalog>? Nodes { get; set; }
    }
}

internal class PriceListApiResponse
{
    public PriceListWithPrices? PriceList { get; set; }

    internal class PriceListWithPrices
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Currency { get; set; }

        public GraphQlConnection<PriceListPrice>? Prices { get; set; }
    }
}
