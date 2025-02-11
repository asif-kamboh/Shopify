using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Views;

public class MetafieldsApiResponse : ShopifyAdminApiResponse
{
    public IList<MetafieldModel>? Metafields { get; set; }
}