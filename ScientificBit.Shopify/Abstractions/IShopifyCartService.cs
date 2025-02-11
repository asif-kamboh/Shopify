using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Abstractions;

public interface IShopifyCartService
{
    Task<ShopifyCartModel?> GetAsync(string cartId, IEnumerable<string> metafieldKeys, string metafieldsNamespace);
}