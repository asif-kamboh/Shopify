namespace Service.Shopify.Models;

public class ShopifyImage : MetafieldsSupportingModel
{
    public string? Url { get; set; }

    public string? AltText { get; set; }

    public int? Height { get; set; }

    public int? Width { get; set; }
}