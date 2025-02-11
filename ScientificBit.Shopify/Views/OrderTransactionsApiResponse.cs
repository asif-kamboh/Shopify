using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Views;

public class OrderTransactionsApiResponse
{
    public IList<ShopifyOrderTransaction>? Transactions { get; set; }
}