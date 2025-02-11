using Service.Shopify.Models;

namespace Service.Shopify.Abstractions;

public interface IShopifyMetaObjectService
{
    Task<MetaObjectModel?> GetAsync(string gid);

    Task<IList<MetaObjectModel>> GetAllAsync(string type);
}