using ScientificBit.Shopify.Builders.Query;
using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Abstractions.Repo;

public interface IShopifyVariantsRepository
{
    Task<GraphQlResult<ShopifyBaseModel>> CreateVariantAsync(string productId, ProductVariantCreateInput variant);

    Task<GraphQlResult<TVariant>> CreateVariantAsync<TVariant>(string productId, ProductVariantCreateInput variant)
        where TVariant : new();

    Task<GraphQlResults<ShopifyBaseModel>> CreateVariantsAsync(string productId,
        IList<ProductVariantCreateInput> variants);

    Task<GraphQlResults<TVariant>> CreateVariantsAsync<TVariant>(string productId,
        IList<ProductVariantCreateInput> variants) where TVariant : new();

    Task<GraphQlResult<ShopifyVariant>> GetVariantAsync(string variantId);

    Task<GraphQlResult<TVariant>> GetVariantAsync<TVariant>(string variantId) where TVariant : new();

    Task<GraphQlResult<TVariant>> GetVariantAsync<TVariant>(string variantId, Action<VariantQueryBuilder> queryBuilder)
        where TVariant : new();

    Task<GraphQlResults<TVariant>> GetVariantsAsync<TVariant>(Action<VariantQueryBuilder> queryBuilder)
        where TVariant : new();

    Task<GraphQlResults<TVariant>> GetVariantsAsync<TVariant>(IList<string> variantIds,
        Action<VariantQueryBuilder> queryBuilder) where TVariant : new ();

    Task<GraphQlResults<TVariant>> GetVariantsAsync<TVariant>(int pageSize, string? cursor,
        Action<VariantQueryBuilder> queryBuilder) where TVariant : new();

    Task<GraphQlResults<ShopifyVariant>> GetVariantsAsync(string productId, Action<VariantQueryBuilder> queryBuilder);

    Task<GraphQlResults<TVariant>> GetVariantsAsync<TVariant>(string productId,
        Action<VariantQueryBuilder> queryBuilder) where TVariant : new();

    Task<GraphQlResult<List<string>>> DeleteVariantAsync(string productId, string variantId);

    Task<GraphQlResult<List<string>>> DeleteVariantsAsync(string productId, IEnumerable<string> variantIds);
}