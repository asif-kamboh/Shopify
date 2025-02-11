using ScientificBit.Shopify.Models;
using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Views;

public class MetaObjectsApiResponse : ShopifyAdminApiResponse
{
    public GraphQlConnection<MetaObjectModel>? MetaObjects { get; set; }
}