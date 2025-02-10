using Service.Shopify.Models;

namespace Service.Shopify.Abstractions;

public interface IShopifyCartService
{
    Task<ShopifyCartModel?> GetAsync(string cartId, IEnumerable<string> metafieldKeys, string metafieldsNamespace);
}