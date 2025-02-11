using Service.Shopify.Models;
using Service.Shopify.Models.Base;

namespace Service.Shopify.Views;

public class MetaObjectsApiResponse : ShopifyAdminApiResponse
{
    public GraphQlConnection<MetaObjectModel>? MetaObjects { get; set; }
}