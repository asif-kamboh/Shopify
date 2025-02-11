namespace ScientificBit.Shopify.Models;

public class ShopifyTranslation
{
    public string? Key { get; set; }

    public string Value { get; set; } = string.Empty;

    public string Locale { get; set; } = "en";
}