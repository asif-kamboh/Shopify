namespace Service.Shopify.Requests;

public class ShopifyOrderCancelRequest
{
    public string Reason { get; set; } = string.Empty;

    public bool Email { get; set; }

    public bool Restock { get; set; }
}