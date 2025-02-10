namespace Service.Shopify.Models;

public class ShopifyCountModel
{
    public int? Count { get; set; }

    public string? Precision { get; set; } // AT_LEAST or EXACT
}