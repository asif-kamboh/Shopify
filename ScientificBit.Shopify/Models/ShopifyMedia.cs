namespace ScientificBit.Shopify.Models;

public class ShopifyMedia : ShopifyBaseModel
{
    public string? Alt { get; set; }

    public string? MediaContentType { get; set; }

    public string? Status { get; set; }

    public MediaPreviewImage? Preview { get; set; }

    public ShopifyImage? Image { get; set; }
}