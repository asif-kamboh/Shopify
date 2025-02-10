using Service.Shopify.Abstractions.Clients;
using Service.Shopify.Abstractions.Repo;
using Service.Shopify.Builders.Query;
using Service.Shopify.Mappers;
using Service.Shopify.Models;
using Service.Shopify.Models.Base;
using Service.Shopify.Requests.Admin.Mutations;
using Service.Shopify.Views;

namespace Service.Shopify.Domain;

internal class ShopifyProductsRepository : IShopifyProductsRepository
{
    private readonly IAdminApiClient _apiClient;

    public ShopifyProductsRepository(IAdminApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public Task<GraphQlResult<ShopifyProduct>> GetProductByIdAsync(string productId)
    {
        return GetProductByIdAsync<ShopifyProduct>(productId);
    }

    public Task<GraphQlResult<TProduct>> GetProductByIdAsync<TProduct>(string productId) where TProduct : new()
    {
        return GetProductByIdAsync<TProduct>(productId, builder =>
        {
            builder.AddVariantsConnection(20, _ => { });
        });
    }

    public async Task<GraphQlResult<TProduct>> GetProductByIdAsync<TProduct>(string productId, Action<ProductQueryBuilder> queryBuilder) where TProduct : new()
    {
        var builder = ProductQueryBuilder.QueryById();

        queryBuilder.Invoke(builder);

        var query = builder.Build(new {Id = productId});
        var response = await _apiClient.RunQueryAsync<ProductGetResponse<TProduct>>(query);

        return GraphQlResultMapper.CreateResult(response.Data.Product, response.Data.UserErrors, response.Errors);
    }

    public Task<GraphQlResult<ShopifyBaseModel>> CreateProductAsync(ProductCreateInput product)
    {
        return CreateProductAsync<ShopifyBaseModel>(product);
    }

    public async Task<GraphQlResult<TProduct>> CreateProductAsync<TProduct>(ProductCreateInput product) where TProduct : new()
    {
        var mutation = new ProductCreateMutation()
        {
            Variables = new
            {
                Product = product
            }
        };
        var response = await _apiClient.RunMutationAsync<ProductGetResponse<TProduct>>(mutation);

        return GraphQlResultMapper.CreateResult(response.Data.Product, response.Data.UserErrors, response.Errors);
    }

    public Task<GraphQlResults<ShopifyProduct>> GetProductsAsync(Action<ProductQueryBuilder> action)
    {
        return GetProductsAsync<ShopifyProduct>(action);
    }

    public async Task<GraphQlResults<TProduct>> GetProductsAsync<TProduct>(Action<ProductQueryBuilder> action)
        where TProduct : new()
    {
        var queryBuilder = ProductQueryBuilder.QueryAll();

        action.Invoke(queryBuilder);

        var query = queryBuilder.Build();

        var response = await _apiClient.RunQueryAsync<ProductsGetResponse<TProduct>>(query);

        return GraphQlResultMapper.CreateResult(response.Data.Products, response.Data.UserErrors, response.Errors);
    }
}

internal class ProductGetResponse<TProduct> : AdminApiResponse where TProduct : new()
{
    public TProduct? Product { get; set; }
}

internal class ProductsGetResponse<TProduct> : AdminApiResponse where TProduct : new()
{
    public GraphQlConnection<TProduct>? Products { get; set; }
}