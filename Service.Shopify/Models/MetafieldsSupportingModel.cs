using Service.Shopify.Models.Base;

namespace Service.Shopify.Models;

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