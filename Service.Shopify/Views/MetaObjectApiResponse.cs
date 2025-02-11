using Service.Shopify.Models;

namespace Service.Shopify.Views;

public class MetaObjectApiResponse : ShopifyAdminApiResponse
{
    public MetaObjectModel? MetaObject { get; set; }
}