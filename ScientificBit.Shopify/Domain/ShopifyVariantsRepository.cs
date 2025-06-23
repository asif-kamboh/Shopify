using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Abstractions.Repo;
using ScientificBit.Shopify.Builders.Query;
using ScientificBit.Shopify.Mappers;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Models.Base;
using ScientificBit.Shopify.Requests.Admin.Mutations;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Domain;

internal class ShopifyVariantsRepository : IShopifyVariantsRepository
{
    private readonly IAdminApiClient _client;

    public ShopifyVariantsRepository(IAdminApiClient client)
    {
        _client = client;
    }

    public Task<GraphQlResult<ShopifyBaseModel>> CreateVariantAsync(string productId, ProductVariantCreateInput variant)
    {
        return CreateVariantAsync<ShopifyBaseModel>(productId, variant);
    }

    public async Task<GraphQlResult<TVariant>> CreateVariantAsync<TVariant>(string productId, ProductVariantCreateInput variant) where TVariant : new()
    {
        var result = await CreateVariantsAsync<TVariant>(productId, new List<ProductVariantCreateInput> {variant});
        return new GraphQlResult<TVariant>
        {
            Data = result.Data.FirstOrDefault(),
            Error = result.Error,
            GraphQlErrors = result.GraphQlErrors
        };
    }

    public Task<GraphQlResults<ShopifyBaseModel>> CreateVariantsAsync(string productId, IList<ProductVariantCreateInput> variants)
    {
        return CreateVariantsAsync<ShopifyBaseModel>(productId, variants);
    }

    public async Task<GraphQlResults<TVariant>> CreateVariantsAsync<TVariant>(string productId, IList<ProductVariantCreateInput> variants) where TVariant : new()
    {
        var mutation = new VariantsCreateMutation
        {
            Variables = new
            {
                ProductId = productId,
                Variants = variants
            }
        };

        var response = await _client.RunMutationAsync<VariantsCreateResponse<TVariant>>(mutation);
        var result = response.Data?.ProductVariantsBulkCreate;

        return GraphQlResultMapper.CreateResult(result?.ProductVariants, result?.UserErrors, response.Errors);
    }

    public Task<GraphQlResult<ShopifyVariant>> GetVariantAsync(string variantId)
    {
        return GetVariantAsync<ShopifyVariant>(variantId);
    }

    public Task<GraphQlResult<TVariant>> GetVariantAsync<TVariant>(string variantId) where TVariant : new()
    {
        return GetVariantAsync<TVariant>(variantId, _ => { });
    }

    public async Task<GraphQlResult<TVariant>> GetVariantAsync<TVariant>(string variantId,
        Action<VariantQueryBuilder> queryBuilder) where TVariant : new()
    {
        var builder = VariantQueryBuilder.QueryById();
        queryBuilder.Invoke(builder);

        var query = builder.Build(new {Id = variantId});

        var response = await _client.RunQueryAsync<VariantGetResponse<TVariant>>(query);

        return GraphQlResultMapper.CreateResult(response.Data.ProductVariant, response.Data.UserErrors, response.Errors);
    }

    public async Task<GraphQlResults<TVariant>> GetVariantsAsync<TVariant>(Action<VariantQueryBuilder> queryBuilder) where TVariant : new()
    {
        var builder = VariantQueryBuilder.QueryAll();
        queryBuilder.Invoke(builder);

        var response = await _client.RunQueryAsync<VariantsGetResponse<TVariant>>(builder.Build());

        return GraphQlResultMapper.CreateResult(response.Data.ProductVariants, response.Data.UserErrors, response.Errors);
    }

    public Task<GraphQlResults<TVariant>> GetVariantsAsync<TVariant>(IList<string> variantIds, Action<VariantQueryBuilder> queryBuilder) where TVariant : new()
    {
        throw new NotImplementedException();
    }

    public Task<GraphQlResults<TVariant>> GetVariantsAsync<TVariant>(int pageSize, string? cursor, Action<VariantQueryBuilder> queryBuilder) where TVariant : new()
    {
        throw new NotImplementedException();
    }

    public Task<GraphQlResults<ShopifyVariant>> GetVariantsAsync(string productId, Action<VariantQueryBuilder> queryBuilder)
    {
        return GetVariantsAsync<ShopifyVariant>(productId, queryBuilder);
    }

    public Task<GraphQlResults<TVariant>> GetVariantsAsync<TVariant>(string productId,
        Action<VariantQueryBuilder> queryBuilder) where TVariant : new()
    {
        throw new NotImplementedException();
    }

    public Task<GraphQlResult<List<string>>> DeleteVariantAsync(string productId, string variantId)
    {
        return DeleteVariantsAsync(productId, new[] {variantId});
    }

    public async Task<GraphQlResult<List<string>>> DeleteVariantsAsync(string productId, IEnumerable<string> variantIds)
    {
        var listOfVariants = variantIds.ToList();
        var mutation = new VariantsDeleteMutation
        {
            Variables = new
            {
                ProductId = productId,
                VariantsIds = listOfVariants
            }
        };
        var response = await _client.RunMutationAsync<VariantsDeleteResponse>(mutation);
        var result = response.Data?.ProductVariantsBulkDelete;

        return GraphQlResultMapper.CreateResult(listOfVariants, result?.UserErrors, response.Errors);
    }
}

internal class VariantGetResponse<TVariant> : AdminApiResponse where TVariant : new()
{
    public TVariant? ProductVariant { get; set; }
}

internal class VariantsCreateResponse<TVariant> where TVariant : new()
{
    public VariantsCreateResult? ProductVariantsBulkCreate { get; set; }

    public class VariantsCreateResult : AdminApiResponse
    {
        public IList<TVariant>? ProductVariants { get; set; }
    }
}

internal class VariantsDeleteResponse
{
    public AdminApiResponse? ProductVariantsBulkDelete { get; set; }
}

internal class VariantsGetResponse<TVariant> : AdminApiResponse where TVariant : new()
{
    public GraphQlConnection<TVariant>? ProductVariants { get; set; }
}