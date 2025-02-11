using Service.Shopify.Abstractions.Clients;
using Service.Shopify.Abstractions.Repo;
using Service.Shopify.Builders.Query;
using Service.Shopify.Mappers;
using Service.Shopify.Models;
using Service.Shopify.Models.Base;
using Service.Shopify.Requests.Admin.Mutations;
using Service.Shopify.Views;

namespace Service.Shopify.Domain;

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

        return GraphQlResultMapper.CreateResult(response.Data.ProductVariants, response.Data.UserErrors,
            response.Errors);
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
}

internal class VariantGetResponse<TVariant> : AdminApiResponse where TVariant : new()
{
    public TVariant? ProductVariant { get; set; }
}

internal class VariantsCreateResponse<TVariant> : AdminApiResponse where TVariant : new()
{
    public IList<TVariant>? ProductVariants { get; set; }
}

internal class VariantsGetResponse<TVariant> : AdminApiResponse where TVariant : new()
{
    public GraphQlConnection<TVariant>? ProductVariants { get; set; }
}