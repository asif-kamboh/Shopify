namespace ScientificBit.Shopify.Models;

public class DraftOrderModel : ShopifyBaseModel
{
    public string Name { get; set; } = string.Empty;

    public OrderInfo? Order { get; set; }

    public class OrderInfo : ShopifyBaseModel
    {
        public string Name { get; set; } = string.Empty;
    }
}