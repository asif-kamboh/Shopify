using ScientificBit.Shopify.Models;

namespace ScientificBit.Shopify.Views;

public class CustomersApiResponse
{
    public IList<ShopifyCustomerInfo?> Customers { get; set; } = new List<ShopifyCustomerInfo?>();
}