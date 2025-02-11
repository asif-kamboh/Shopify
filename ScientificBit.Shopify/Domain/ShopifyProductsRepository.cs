using ScientificBit.Shopify.Abstractions.Clients;
using ScientificBit.Shopify.Abstractions.Repo;
using ScientificBit.Shopify.Builders.Query;
using ScientificBit.Shopify.Mappers;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Models.Base;
using ScientificBit.Shopify.Requests.Admin.Mutations;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Domain;

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