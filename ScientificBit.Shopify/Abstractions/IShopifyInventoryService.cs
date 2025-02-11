using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Abstractions;

public interface IShopifyInventoryService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="inventoryItemId"></param>
    /// <returns></returns>
    Task<ShopifyInventoryItem?> GetInventoryItemAsync(long inventoryItemId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inventoryItemId"></param>
    /// <returns></returns>
    Task<ShopifyInventoryItem?> GetInventoryItemAsync(string inventoryItemId);
}