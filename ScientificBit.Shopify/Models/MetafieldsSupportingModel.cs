using ScientificBit.Shopify.Models.Base;

namespace ScientificBit.Shopify.Models;

public interface IMetafieldsSupportingModel
{
    MetafieldModel? Metafield { get; set; }

    GraphQlConnection<MetafieldModel>? Metafields { get; set; }
}

public class MetafieldsSupportingModel : ShopifyBaseModel, IMetafieldsSupportingModel
{
    public MetafieldModel? Metafield { get; set; }

    public GraphQlConnection<MetafieldModel>? Metafields { get; set; }
}