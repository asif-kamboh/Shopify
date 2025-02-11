using Service.Shopify.Builders.Query;
using Service.Shopify.Models;
using Service.Shopify.Views;

namespace Service.Shopify.Abstractions.Repo;

public interface IShopifyProductsRepository
{
    Task<GraphQlResult<ShopifyProduct>> GetProductByIdAsync(string productId);

    Task<GraphQlResult<TProduct>> GetProductByIdAsync<TProduct>(string productId) where TProduct : new();

    Task<GraphQlResult<TProduct>> GetProductByIdAsync<TProduct>(string productId,
        Action<ProductQueryBuilder> queryBuilder) where TProduct : new();

    Task<GraphQlResult<ShopifyBaseModel>> CreateProductAsync(ProductCreateInput product);

    Task<GraphQlResult<TProduct>> CreateProductAsync<TProduct>(ProductCreateInput product) where TProduct : new();

    Task<GraphQlResults<TProduct>> GetProductsAsync<TProduct>(Action<ProductQueryBuilder> action)
        where TProduct : new();
}