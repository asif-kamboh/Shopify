using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Views;

namespace ScientificBit.Shopify.Abstractions.Repo;

public interface IShopifyMarketCatalogsRepository
{
    Task<GraphQlResult<ShopifyCatalog>> GetMarketCatalogAsync(string query);

    Task<GraphQlResult<PriceListPrice?>> GetVariantPriceAsync(string priceListId, string variantId);

    Task<GraphQlResults<PriceListPrice>> GetVariantPricesAsync(string priceListId, IList<string> variantIds);

    Task<GraphQlResult<PriceListPrice?>> UpdateVariantPriceAsync(string priceListId, PriceListPriceInput prices);

    Task<GraphQlResults<PriceListPrice>> UpdateVariantPricesAsync(string priceListId,
        IList<PriceListPriceInput> prices);
}