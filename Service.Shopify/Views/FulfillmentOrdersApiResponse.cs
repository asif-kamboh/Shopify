using Service.Shopify.Models;

namespace Service.Shopify.Views;

public class FulfillmentOrdersApiResponse
{
    public IList<ShopifyFulfillmentOrder> FulfillmentOrders { get; set; } = new List<ShopifyFulfillmentOrder>();
}