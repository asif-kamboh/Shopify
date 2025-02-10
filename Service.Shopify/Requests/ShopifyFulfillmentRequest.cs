using Service.Shopify.Models;

namespace Service.Shopify.Requests;

public class ShopifyFulfillmentRequest
{
    public ShopifyFulfillment Fulfillment { get; }

    private ShopifyFulfillmentRequest(ShopifyFulfillment fulfillment)
    {
        Fulfillment = fulfillment;
    }

    public class ShopifyFulfillment
    {
        public IList<FulfillmentOrder>?  LineItemsByFulfillmentOrder { get; set; }
    }

    public class FulfillmentOrder
    {
        public long FulfillmentOrderId { get; set; }
        
        public IList<FulillmentOrderLineItem>? FulfillmentOrderLineItems { get; set; }
    }

    public class FulillmentOrderLineItem
    {
        public long Id { get; set; }
        
        public int Quantity { get; set; }
    }

    public static ShopifyFulfillmentRequest Create(ShopifyFulfillmentOrder.LineItem lineItem)
    {
        return Create(lineItem.FulfillmentOrderId, new List<ShopifyFulfillmentOrder.LineItem> {lineItem});
    }

    public static ShopifyFulfillmentRequest Create(long fulfillmentOrderId, IList<ShopifyFulfillmentOrder.LineItem> lineItems)
    {
        var fulfillmentOrderLineItems = lineItems.Select(item => new FulillmentOrderLineItem
        {
            Id = item.Id,
            Quantity = item.FulfillableQuantity
        }).ToList();

        var fulfillmentOrder = new FulfillmentOrder
        {
            FulfillmentOrderId = fulfillmentOrderId,
            FulfillmentOrderLineItems = fulfillmentOrderLineItems
        };

        return new ShopifyFulfillmentRequest(new ShopifyFulfillment
        {
            LineItemsByFulfillmentOrder = new List<FulfillmentOrder> { fulfillmentOrder }
        });
    }
}