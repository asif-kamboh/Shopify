using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

public class ShopifyCartModel : ShopifyBaseModel
{
    public GraphQlConnection<ShopifyCartLine>? Lines { get; set; }
}