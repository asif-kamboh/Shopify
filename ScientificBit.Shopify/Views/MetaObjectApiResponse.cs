using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Views;

public class MetaObjectApiResponse : ShopifyAdminApiResponse
{
    public MetaObjectModel? MetaObject { get; set; }
}