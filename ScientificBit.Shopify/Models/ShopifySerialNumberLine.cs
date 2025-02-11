namespace ScientificBit.Shopify.Models;

public class ShopifySerialNumberLine
{
    public string? Sku { get; set; }

    public IList<string> SerialNumbers { get; set; } = new List<string>();
}