using Service.Shopify.Models;

namespace Service.Shopify.Views;

public class MetafieldApiResponse : ShopifyAdminApiResponse
{
    public MetafieldModel? Metafield { get; set; }
}