using Service.Shopify.Models;

namespace Service.Shopify.Views;

public class MetafieldsApiResponse : ShopifyAdminApiResponse
{
    public IList<MetafieldModel>? Metafields { get; set; }
}