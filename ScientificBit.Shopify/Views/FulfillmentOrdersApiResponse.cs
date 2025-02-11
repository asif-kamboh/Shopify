using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Views;

public class FulfillmentOrdersApiResponse
{
    public IList<ShopifyFulfillmentOrder> FulfillmentOrders { get; set; } = new List<ShopifyFulfillmentOrder>();
}