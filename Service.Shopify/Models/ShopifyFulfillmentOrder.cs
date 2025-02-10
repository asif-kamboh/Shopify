namespace Service.Shopify.Models;

public class ShopifyFulfillmentOrder
{
    public long Id { get; set; }

    public IList<LineItem> LineItems { get; set; } = new List<LineItem>();

    public class LineItem
    {
        public long Id { get; set; }

        public long FulfillmentOrderId { get; set; }

        public int FulfillableQuantity { get; set; }

        public int Quantity { get; set; }

        public long LineItemId { get; set; }

        public long VariantId { get; set; }
    }
}