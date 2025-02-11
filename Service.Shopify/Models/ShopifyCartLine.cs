namespace Service.Shopify.Models;

public class ShopifyCartLine : ShopifyBaseModel
{
    public CartVariantInfo? Merchandise { get; set; }
}