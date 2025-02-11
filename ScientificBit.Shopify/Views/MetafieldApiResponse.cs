using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Views;

public class MetafieldApiResponse : ShopifyAdminApiResponse
{
    public MetafieldModel? Metafield { get; set; }
}