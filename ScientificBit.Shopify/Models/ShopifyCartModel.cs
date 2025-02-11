using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public class ShopifyCartModel : ShopifyBaseModel
{
    public GraphQlConnection<ShopifyCartLine>? Lines { get; set; }
}