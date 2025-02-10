using Service.Shopify.Models;

namespace Service.Shopify.Views;

public class OrderTransactionsApiResponse
{
    public IList<ShopifyOrderTransaction>? Transactions { get; set; }
}