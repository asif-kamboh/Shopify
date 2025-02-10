namespace Service.Shopify.Models;

public class ProductOption : ShopifyBaseModel
{
    public string? Name { get; set; }

    public int? Position { get; set; }

    public IList<string>? Values { get; set; }

    public IList<ShopifyTranslation>? Translations { get; set; }

    public LinkedMetafieldModel? LinkedMetafield { get; set; }
}